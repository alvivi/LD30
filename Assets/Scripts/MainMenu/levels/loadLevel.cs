using UnityEngine;
using System.Collections;

public class loadLevel : MonoBehaviour {

	GameObject text;
	bool flagClick = false;
	GameObject persistente;
	string num;
	// Use this for initialization
	void Start () {
		text = transform.Find("lvlNumber").gameObject;
		num = text.GetComponent<TextMesh>().text;
		if(PlayerPrefs.GetInt("levelCompleted") +1 < int.Parse(num)){
			this.GetComponent<BoxCollider2D>().enabled = false;
			Color color = Color.black;
			color.a = 0.4f;
			this.GetComponent<SpriteRenderer>().color = color;
		}
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
			string lvl = "lvl-"+num;
			persistente.GetComponent<PersistenteScript>().setLevel(lvl);
			Application.LoadLevel(lvl);
		}
	}

	void OnMouseExit () {
		flagClick = false;
	}
}
