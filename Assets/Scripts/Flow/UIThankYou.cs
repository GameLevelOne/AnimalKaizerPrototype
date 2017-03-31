using UnityEngine.SceneManagement;
using UnityEngine;

public class UIThankYou : MonoBehaviour {

	public Fader fader;

	void Start () {
		fader.FadeIn ();
	}
	public void NextScene () {
		fader.FadeOut ();
		fader.OnFadeOutFinished += FadeFinished;
	}	
	void FadeFinished()
	{
		fader.OnFadeOutFinished -= FadeFinished;
		SceneManager.LoadScene ("Scene Title");
	}
}
