using UnityEngine;
using System.Collections;

public class sounds : MonoBehaviour {

	private static bool created = false;
	// Use this for initialization

	public AudioClip jump;
	public AudioClip die;

	void Awake () {
		if (!created) {
			DontDestroyOnLoad(this.gameObject);
			created = true;
		} else {
			Destroy(this.gameObject);
		}	
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
