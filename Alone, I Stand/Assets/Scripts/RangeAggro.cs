using UnityEngine;
using System.Collections;

public class RangeAggro : MonoBehaviour {
	public float range = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject target = GameObject.FindWithTag ("Player");
		if (Vector3.Distance (target.transform.position, gameObject.transform.position) < range) {
			GetComponentInParent<EnemyController> ().target = target;
		}
	}
		
}
