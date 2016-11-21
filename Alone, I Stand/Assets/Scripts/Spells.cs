using UnityEngine;
using System.Collections;

public class Spells : MonoBehaviour {

	public GameObject magicShoot;
	public GameObject character;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MagicShoot(){
		if (Input.GetButtonDown ("Jump")) {
			GameObject obj = (GameObject)(Instantiate(magicShoot, transform.position, GetComponentInParent<Transform> ().rotation));
			obj.tag = "Shoot";
			obj.GetComponent<Shoot> ().shooter = character;
			Debug.Log (obj.GetComponent<Shoot> ().shooter.transform.position);
		}
	}
}
