using UnityEngine;
using System.Collections;

public class MainCharacter : MonoBehaviour {

	private Atributes character;
	private Rigidbody2D controller;
	private Animator animator;
	private Spells spells;
	public float speed;

	// Use this for initialization
	void Start () {
		character = GetComponent<Atributes> ();
		animator = GetComponent<Animator> ();
		character = GetComponent<Atributes> ();
		controller = GetComponent<Rigidbody2D> ();
		spells = GetComponentInChildren<Spells> ();
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
		spells.MagicShoot ();

	}

	public void PlayerAttack(){
		if(Input.GetButtonDown("Fire1"))
			animator.SetTrigger ("Attack");
	}

	public void PlayerDefence(){
		if (character.GetShiHp () > 0) 
			if (Input.GetButtonDown ("Fire2"))
				animator.SetBool ("Defence", true);
		if (Input.GetButtonUp ("Fire2") || character.GetShiHp () <= 0)
			animator.SetBool ("Defence", false);
		
	}
}
