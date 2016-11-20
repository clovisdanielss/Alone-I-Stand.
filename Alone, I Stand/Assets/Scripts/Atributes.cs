using UnityEngine;
using System.Collections;

public class Atributes : MonoBehaviour {

	public int hp;
	public int dmg;
	public int exp;
	public int defence;
	public int knockback;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Tree" || coll.tag == "Player" || coll.tag == "Enemy") {
			Atributes at = coll.GetComponentInParent<Atributes> ();
			int totaldmg = at.defence - dmg;
			if (totaldmg < 0) {
				at.hp += totaldmg;
				if(coll.tag == "Enemy")
					coll.GetComponent<Rigidbody2D> ().AddForce (transform.up * knockback);
			}
			Debug.Log (at.hp);
			if (at.hp <= 0)
				Destroy (coll.gameObject);
		}

	}

}
