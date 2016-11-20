using UnityEngine;
using System.Collections;

public class SpiderController : MonoBehaviour {

	private Atributes spider;
	public GameObject player;


	// Use this for initialization
	void Start () {
		spider = GetComponent<Atributes> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		Quaternion rot = Quaternion.LookRotation (transform.position - player.transform.position  , Vector3.forward);
		Debug.Log (player.transform.position);
		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		GetComponent<Rigidbody2D>().angularVelocity = 0;

	}
}
