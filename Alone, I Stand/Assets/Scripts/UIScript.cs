using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Text[] array = GetComponentsInChildren<Text> ();
		foreach (Text t in array) {
			if (t.name == "HP") {
				t.text = "HP : " + player.GetComponent<Atributes> ().GetHp()+"|"+ player.GetComponent<Atributes> ().GetShiHp();
			}
			if (t.name == "MP") {
				if (player.GetComponentInChildren<Spells> ().isReady ())
					t.text = "Magia Pronta!";
				else
					t.text = "Acumulando Magia.";
			}
		}
	}
}
