using UnityEngine;
using System.Collections;

public class Pinchos : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.gameObject.tag == "pinchosR" || coll.gameObject.tag == "pinchosG" || coll.gameObject.tag == "pinchos"){
			this.GetComponent<PlayerControlScript>().setAlive(false);
		}
	}
}
