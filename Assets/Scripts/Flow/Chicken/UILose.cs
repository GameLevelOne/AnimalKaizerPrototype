﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class UILose : MonoBehaviour {

	string tempSceneName;

	void OnEnable(){
		ScenePayoutManager.Instance.fader.OnFadeOutFinished += ButtonClick;
	}

	public void ButtonOnClick(string sceneName){
		tempSceneName = sceneName;
		ScenePayoutManager.Instance.fader.FadeOut();
	}

	void ButtonClick(){
		ScenePayoutManager.Instance.fader.OnFadeOutFinished -= ButtonClick;
		SceneManager.LoadScene (tempSceneName);
	}
}
