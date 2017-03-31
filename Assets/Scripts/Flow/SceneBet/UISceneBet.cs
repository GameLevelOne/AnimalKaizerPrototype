using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISceneBet : MonoBehaviour {

	public Payout payout;
	public Fader fader;

	void Start () {
		payout.InitPayout ();		
		fader.FadeIn ();
	}
	public void NextScene () {
		fader.FadeOut ();
		fader.OnFadeOutFinished += FadeFinished;
	}	
	void FadeFinished()
	{
		fader.OnFadeOutFinished -= FadeFinished;
		SceneManager.LoadScene ("Scene Selection");
	}

}
