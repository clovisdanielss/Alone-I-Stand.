using UnityEngine;
using System.Collections;

public class MainCharacter : MonoBehaviour {

	private Atributes character;
	private Rigidbody2D controller;
	private Animator animator;
	public float speed;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		character = GetComponent<Atributes> ();
		controller = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		var mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation (transform.position - mousePos, Vector3.forward);

		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		controller.angularVelocity = 0;

		float input = Input.GetAxis ("Vertical");

		controller.AddForce (transform.up * input * speed);

		Vector3 camPos = new Vector3 (controller.transform.position.x, 
			controller.transform.position.y, Camera.main.transform.position.z);

		Camera.main.transform.position = camPos;

		PlayerAttack ();
		PlayerDefence ();


	}

	public void PlayerAttack(){
		if(Input.GetButtonDown("Fire1"))
			animator.SetTrigger ("Attack");
	}

	public void PlayerDefence(){
		if (Input.GetButtonDown ("Fire2"))
			animator.SetBool ("Defence", true);
		if(Input.GetButtonUp ("Fire2"))
			animator.SetBool ("Defence", false);
	}
}
