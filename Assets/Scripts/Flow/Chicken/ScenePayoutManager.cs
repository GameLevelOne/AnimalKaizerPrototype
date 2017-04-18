using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePayoutManager : MonoBehaviour {
	static ScenePayoutManager instance = null;
	public static ScenePayoutManager Instance{ get{ return instance; } }

	public Fader fader;

	public GameObject uiWin, uiLose;

	void Awake(){
		if (instance != null && instance != this) {
			// destroy any other singleton object of this class
			Destroy(this.gameObject);  
			return;
		} else instance = this;
	}

	void Start(){
		ShowUIWinLose();
		fader.FadeIn();
	}

	void ShowUIWinLose(){
		int temp = PlayerPrefs.GetInt ("PlayerWin");
		if (temp == 1) {
			uiWin.SetActive (true);
			uiLose.SetActive (false);


		}
		else {
			uiWin.SetActive (false);
			uiLose.SetActive (true);
		}
	}

}
