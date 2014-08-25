using UnityEngine;
using System.Collections;

public class CambiarColor : MonoBehaviour {



	GameObject[] tagR;
	GameObject[] tagG;

	GameObject[] tagPR;
	GameObject[] tagPG;

	GameObject player;

	ParticleSystem chispas;

	Color colorR;
	Color colorB;

	// Use this for initialization
	void Start () {
		tagR = GameObject.FindGameObjectsWithTag("red");
		tagG = GameObject.FindGameObjectsWithTag("green");
		tagPR = GameObject.FindGameObjectsWithTag("pinchosR");
		tagPG = GameObject.FindGameObjectsWithTag("pinchosG");

		player = GameObject.Find("player");

		chispas = GameObject.Find("Chispas").GetComponent<ParticleSystem>();

		colorR = new Color(223f/255f, 69f/255f, 96f/255f);
		colorB = new Color(106f/255f, 210f/255f, 232f/255f);

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.gameObject.tag == "barraGreen"){
			chispas.startColor = colorB;
			for(int i = 0; i < tagG.Length; i++){
				tagG[i].GetComponent<BoxCollider2D>().enabled = true;
			}
			for(int i = 0; i < tagR.Length; i++){
				tagR[i].GetComponent<BoxCollider2D>().enabled = false;
				if(tagR[i].GetComponent<bloques>().collision){
					tagR[i].GetComponent<bloques>().collision = false;
					player.GetComponent<PlayerControlScript>().setMinusCollisions();
				}
			}

			for(int i = 0; i < tagPG.Length; i++){
				tagPG[i].GetComponent<BoxCollider2D>().enabled = true;
			}
			for(int i = 0; i < tagPR.Length; i++){
				tagPR[i].GetComponent<BoxCollider2D>().enabled = false;
			}
		}

		if(coll.gameObject.tag == "barraRed"){
			chispas.startColor = colorR;
			for(int i = 0; i < tagR.Length; i++){
				tagR[i].GetComponent<BoxCollider2D>().enabled = true;
			}
			for(int i = 0; i < tagG.Length; i++){
				tagG[i].GetComponent<BoxCollider2D>().enabled = false;
				if(tagG[i].GetComponent<bloques>().collision){
					tagG[i].GetComponent<bloques>().collision = false;
					player.GetComponent<PlayerControlScript>().setMinusCollisions();
				}
			}

			for(int i = 0; i < tagPR.Length; i++){
				tagPR[i].GetComponent<BoxCollider2D>().enabled = true;
			}
			for(int i = 0; i < tagPG.Length; i++){
				tagPG[i].GetComponent<BoxCollider2D>().enabled = false;
			}
		}
	}
}
