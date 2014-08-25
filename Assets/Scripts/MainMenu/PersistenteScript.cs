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
		else if(lvlName == "lvl-3")
			currentLvl = 3;
		else if(lvlName == "lvl-4")
			currentLvl = 4;
		else if(lvlName == "lvl-5")
			currentLvl = 5;
		else if(lvlName == "lvl-6")
			currentLvl = 6;
		else if(lvlName == "lvl-7")
			currentLvl = 7;
		else if(lvlName == "lvl-8")
			currentLvl = 8;
		else if(lvlName == "lvl-9")
			currentLvl = 9;
	}

	public string nextLevelName(string lvlName){
		if(lvlName == "lvl-0")
			return "lvl-1";
		else if(lvlName == "lvl-1")
			return "lvl-2";
		else if(lvlName == "lvl-2")
			return "lvl-3";
		else if(lvlName == "lvl-3")
			return "lvl-4";
		else if(lvlName == "lvl-4")
			return "lvl-5";
		else if(lvlName == "lvl-5")
			return "lvl-6";
		else if(lvlName == "lvl-6")
			return "lvl-7";
		else if(lvlName == "lvl-7")
			return "lvl-8";
		else if(lvlName == "lvl-8")
			return "lvl-9";

		return "MainMenu";
	}

	public int getCurrentLevel() {
		return currentLvl;
	}

	public void setCurrentLevel() {
		currentLvl++;
	}



}
