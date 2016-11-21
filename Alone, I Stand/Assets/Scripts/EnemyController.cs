using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private Atributes spider;
	public GameObject target;
	public float speed, force;


	// Use this for initialization
	void Start () {
		spider = GetComponent<Atributes> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			// Não entendi, mas é necessário o -10 no Z. Descobri atravez das coordenads do mouse que uso para
			// rotacionar o personagem.
			Quaternion rot = Quaternion.LookRotation (transform.position - new Vector3 (target.transform.position.x,
				                target.transform.position.y, -10), Vector3.forward);
			transform.rotation = rot;
			transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
			GetComponent<Rigidbody2D> ().angularVelocity = 0;
			GetComponent<Rigidbody2D> ().AddForce (transform.up * speed * force);
		}

	}
}
