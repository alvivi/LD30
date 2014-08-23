using UnityEngine;
using System.Collections;

public class loadLevel : MonoBehaviour {

	GameObject text;
	bool flagClick = false;
	GameObject persistente;
	// Use this for initialization
	void Start () {
		text = transform.Find("lvlNumber").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown () {
		flagClick = true;
	}

	void OnMouseUpAsButton () {
		if(flagClick){
			persistente = GameObject.Find("Persistente");
			string lvl = "lvl-"+text.GetComponent<TextMesh>().text;
			persistente.GetComponent<PersistenteScript>().setLevel(lvl);
			Application.LoadLevel(lvl);
		}
	}

	void OnMouseExit () {
		flagClick = false;
	}
}
