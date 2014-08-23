using UnityEngine;
using System.Collections;

public class MoverBarra : MonoBehaviour {

	public float barraSpeed;
	Vector3 position;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		position = this.transform.localPosition;
		position.x -= barraSpeed * Time.deltaTime;
		this.transform.localPosition = position;

		if(this.transform.localPosition.x <= -16f)
			position.x = 32f;
			this.transform.localPosition = position;
	}
}
