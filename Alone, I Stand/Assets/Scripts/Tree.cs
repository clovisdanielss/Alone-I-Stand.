using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

	private Atributes tree;
	public Sprite deadtree;
	// Use this for initialization
	void Start () {
		tree = GetComponent<Atributes> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (tree.hp < 5) {
			GetComponent<SpriteRenderer> ().sprite = deadtree;
		}
			
	}
}
