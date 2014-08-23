using UnityEngine;
using System.Collections;

public class CambiarColor : MonoBehaviour {



	GameObject[] tagR;
	GameObject[] tagG;


	// Use this for initialization
	void Start () {
		tagR = GameObject.FindGameObjectsWithTag("red");
		tagG = GameObject.FindGameObjectsWithTag("green");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.gameObject.tag == "barraGreen"){
			for(int i = 0; i < tagG.Length; i++){
				tagG[i].GetComponent<BoxCollider2D>().enabled = true;
			}
			for(int i = 0; i < tagR.Length; i++){
				tagR[i].GetComponent<BoxCollider2D>().enabled = false;
			}
		}

		if(coll.gameObject.tag == "barraRed"){
			for(int i = 0; i < tagR.Length; i++){
				tagR[i].GetComponent<BoxCollider2D>().enabled = true;
			}
			for(int i = 0; i < tagG.Length; i++){
				tagG[i].GetComponent<BoxCollider2D>().enabled = false;
			}
		}
	}
}
