using UnityEngine;
using System.Collections;

public class TitleScreenBackground : MonoBehaviour {

	public float speed = 0.5f;
	public float maxx = 10;
	public float minx = -10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var p = this.transform.position;
		p.x += speed * Time.deltaTime;
		if (p.x > maxx) {
			p.x = minx;
		}
		this.transform.position = p;
	}
}
