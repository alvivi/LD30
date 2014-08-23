using UnityEngine;
using System.Collections;

public class PersistenteScript : MonoBehaviour {

	private static bool created = false;

	int currentLvl = 0;
	// Use this for initialization
	void Awake() {
		Application.targetFrameRate = 60;
		QualitySettings.vSyncCount = 0;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		if (!created) {
			DontDestroyOnLoad(this.gameObject);
			created = true;
		} else {
			Destroy(this.gameObject);
		}	
		
	}

	void Start() {
		if(!PlayerPrefs.HasKey("levelCompleted")){
			PlayerPrefs.SetInt("levelCompleted", -1);
		}
	}

	public void setLevel(string lvlName){
		if(lvlName == "lvl-0")
			currentLvl = 0;
		else if(lvlName == "lvl-1")
			currentLvl = 1;
		else if(lvlName == "lvl-2")
			currentLvl = 2;
	}

	public string nextLevelName(string lvlName){
		if(lvlName == "lvl-0")
			return "lvl-1";
		else if(lvlName == "lvl-1")
			return "lvl-2";

		return "MainMenu";
	}

	public int getCurrentLevel() {
		return currentLvl;
	}



}
