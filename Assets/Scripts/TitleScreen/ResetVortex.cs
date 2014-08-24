using UnityEngine;
using System.Collections;

public class ResetVortex : MonoBehaviour {

	public float speed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var vortex = this.GetComponent<VortexEffect>();

		vortex.angle += speed * Time.deltaTime;

		if (vortex.angle > 0) {
			vortex.angle = 0;
			Destroy(this);
		}
	}
}
