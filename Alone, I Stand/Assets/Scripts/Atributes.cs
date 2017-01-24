using UnityEngine;
using System.Collections;

public class Atributes : MonoBehaviour {

	public int maxHp;
	private int hp;
	private int shiHp;
	public int shiMaxHp;
	public int dmg;
	public int exp;
	public int defence;
	public int knockback;
	private float time;

	// Use this for initialization
	void Start () {
		hp = maxHp;
		shiHp = shiMaxHp;
	}
	
	// Update is called once per frame
	void Update () {
		RestaureShield ();
	}

	public void RestaureShield(){

		if (shiHp < shiMaxHp) {
			time += Time.deltaTime;
			if (shiHp == 0) {
				time -= 3*Time.deltaTime;
				if (time < -3)
					time = 1;
			}
			if (time > .25) {
				time = 0;
				shiHp++;
			}
		}
	}

	public int GetHp(){
		return hp;
	}

	public int GetShiHp (){
		return shiHp;
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.layer != 9) {
			if (tag == "Player" || (tag == "Enemy" && GetComponent<EnemyController> ().target != null)) {
				if (coll.tag == "Tree" || coll.tag == "Player" || coll.tag == "Enemy") {
					Atributes at = coll.GetComponentInParent<Atributes> ();
					int totaldmg = at.defence - dmg;
					if (totaldmg < 0) {
						at.hp += totaldmg;
						if (coll.tag == "Enemy" || coll.tag == "Player") {
							Vector3 direction = coll.transform.position - transform.position;
							direction = direction.normalized;
							coll.GetComponent<Rigidbody2D> ().AddForce (direction * knockback);
						}
					}
					if (at.hp <= 0)
						Destroy (coll.gameObject);
				}
			}
			Debug.Log ("Tag :" + tag + "coll.tag: " + coll.tag);
			if ((tag == "Shoot" || tag == "Enemy") && (coll.tag == "Shield" || coll.tag == "Player")) {
				Vector3 direction = coll.transform.position - transform.position;
				direction = direction.normalized;
				GetComponent<Rigidbody2D> ().AddForce (-direction * knockback);
				if (coll.tag == "Shield" && coll.gameObject.GetComponentInParent<Atributes>().shiHp > 0) {
					coll.GetComponentInParent<Animator> ().SetTrigger ("Block");
					coll.gameObject.GetComponentInParent<Atributes> ().shiHp -= dmg;
					if (coll.gameObject.GetComponentInParent<Atributes> ().shiHp < 0)
						coll.gameObject.GetComponentInParent<Atributes> ().shiHp = 0;					
				}

			}
			if (tag == "Shoot") {
				Atributes at = coll.GetComponentInParent<Atributes> ();
				int totaldmg = -dmg;
				Debug.Log (at.hp);
				if (totaldmg < 0) {
					at.hp += totaldmg;
					if (coll.tag == "Enemy") {
						coll.GetComponentInParent<EnemyController> ().target = GetComponent<Shoot> ().shooter;
					}
				}
				if (at.hp <= 0)
					Destroy (coll.gameObject);
				Destroy (gameObject);
			}
		}

	}

}
