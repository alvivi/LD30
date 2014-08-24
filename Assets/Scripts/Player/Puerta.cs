using UnityEngine;
using System.Collections;

public class Puerta : MonoBehaviour {

	GameObject persistente;
	// Use this for initialization
	void Start () {
		persistente = GameObject.Find ("Persistente");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag == "puerta"){
			string nextLvl = persistente.GetComponent<PersistenteScript>().nextLevelName(Application.loadedLevelName);
			int num = persistente.GetComponent<PersistenteScript>().getCurrentLevel();
			PlayerPrefs.SetInt("levelCompleted", num);
			persistente.GetComponent<PersistenteScript>().setCurrentLevel();
			Application.LoadLevel(nextLvl);
		}

	}
}
