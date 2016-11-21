using UnityEngine;
using System.Collections;

public class RangeAggro : MonoBehaviour {
	public float range;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponentInParent<EnemyController> ().target != null)
			GetComponent<CircleCollider2D> ().enabled = false;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			GetComponentInParent<EnemyController> ().target = col.gameObject;
			GetComponent<CircleCollider2D> ().enabled = false;
		}
	}
}
