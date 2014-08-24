using UnityEngine;
using System.Collections;

public class TitleLogo : MonoBehaviour {

	public float minTime = 0.1f;
	public float maxTime = 0.3f;
	public float horizontalDiff = 0.5f;
	public float verticalDiff = 0.5f;

	public Vector3 pos;
	public float lastTick;
	public float targetTickDiff;

	// Use this for initialization
	void Start () {
		pos = transform.position;
	}

	void StartTick () {
		targetTickDiff = Random.Range (minTime, maxTime);
		lastTick = Time.time;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time - lastTick > targetTickDiff) {
			if (transform.position == pos) {
				var x = transform.position.x + Random.Range(-horizontalDiff, horizontalDiff);
				var y = transform.position.y + Random.Range(-verticalDiff, verticalDiff);
				var p = transform.position;
				p.x = x;
				p.y = y;
				transform.position = p;
			} else {
				transform.position = pos;
			}
			StartTick();
		}
	}
}
