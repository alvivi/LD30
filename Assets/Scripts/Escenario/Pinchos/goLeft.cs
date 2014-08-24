using UnityEngine;
using System.Collections;

public class goLeft : MonoBehaviour {

	public float speed;
	public float right;
	public float left;

	Vector3 position;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		position = transform.position;
		position.x -= speed * Time.deltaTime;
		if(position.x <= left)
			position.x = right;
		transform.position = position;
	}
}
