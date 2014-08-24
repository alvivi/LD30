using UnityEngine;
using System.Collections;

public class LevelControls : MonoBehaviour {

	void Update () {
		if(Input.GetKeyDown(KeyCode.R)){
			Application.LoadLevel(Application.loadedLevelName);
		}

		if(Input.GetKeyDown(KeyCode.P)){
			if(Time.timeScale != 0f)
				Time.timeScale = 0f;
			else
				Time.timeScale = 1f;
		}

		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.LoadLevel("MainMenu");
		}
	}
}
