using UnityEngine;
using System.Collections;

public class falling : MonoBehaviour {

	public float top;
	public float bot;
	public float speed;

	Vector3 position;
	// Use this for initialization
	void Start () {
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		position = transform.position;
		position.y -= speed * Time.deltaTime;
		if(position.y <= bot)
			position.y = top;
		transform.position = position;
	}
}
