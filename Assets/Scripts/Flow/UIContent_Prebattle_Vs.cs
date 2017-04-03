using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIContent_Prebattle_Vs : MonoBehaviour {

	public Fader fader;

	void GoToGameScene(){
		fader.FadeOut ();
		fader.OnFadeOutFinished += FadeFinished;
	}
	void FadeFinished()
	{
		fader.OnFadeOutFinished -= FadeFinished;
        //SceneManager.LoadScene ("Scene Game");
        SceneManager.LoadScene("Scene Game - Helga");
    }
}
