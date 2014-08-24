using UnityEngine;
using System.Collections;

public class bloques : MonoBehaviour {

	public bool collision = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(){
		collision = true;
	}

	void OnCollisionExit2D(){
		collision = false;
	}

}
