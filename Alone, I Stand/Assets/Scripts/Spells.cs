using UnityEngine;
using System.Collections;

public class Spells : MonoBehaviour {

	public GameObject magicShoot;
	public GameObject character;
	private bool isShooted;
	private float coldown;

	// Use this for initialization
	void Start () {
		isShooted = false;
		coldown = 0;
	}
	
	// Update is called once per frame
	void Update () {
		coldown += Time.deltaTime;
		if (coldown > 3) {
			isShooted = false;
			coldown = 0;
		}
	}

	public bool isReady(){
		return !isShooted;
	}

	public void MagicShoot(){
		if (Input.GetButtonDown ("Jump") && !isShooted) {
			GameObject obj = (GameObject)(Instantiate(magicShoot, transform.position, GetComponentInParent<Transform> ().rotation));
			obj.tag = "Shoot";
			obj.GetComponent<Shoot> ().shooter = character;
			Debug.Log (obj.GetComponent<Shoot> ().shooter.transform.position);
			isShooted = true;
		}
	}
		
}
