using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public float speed;
	public string shootertag;
	public float range;
	private float a,b,x,y;
	public GameObject shooter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bool toDestroy = false;
		GetComponent<Rigidbody2D> ().velocity = transform.up * speed;
		tag = shootertag;
		if (x == a && x == b && x == y && y == a && y == b) {
			x = transform.position.x;
			y = transform.position.y;
		}
		a = transform.position.x;
		b = transform.position.y;
		if (a > x && a - x > range)
			toDestroy = true;
		if (a < x && x - a > range)
			toDestroy = true;
		if (b > y && b - y > range)
			toDestroy = true;
		if (b < y && y - b > range)
			toDestroy = true;
		if (toDestroy) {
			Destroy (gameObject);
		}
	}
}
