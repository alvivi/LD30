using UnityEngine;
using System.Collections;

public class LoadMenu : MonoBehaviour {

	SpriteRenderer sp;
	Color colorPush;
	bool flagPush = false;
	// Use this for initialization
	void Start () {
		sp = GetComponent<SpriteRenderer>();
		colorPush = new Color32(180,40,40,255);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown () {
		sp.color = colorPush;
		flagPush = true;
	}

	void OnMouseUpAsButton () {
		if(flagPush){
			Application.LoadLevel("MainMenu");
		}
	}

	void OnMouseExit () {
		flagPush = false;
		sp.color = Color.white;
	}

}
