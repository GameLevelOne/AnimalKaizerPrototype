using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChickenSelectionManager : MonoBehaviour {
	static SceneChickenSelectionManager instance = null;

	public static SceneChickenSelectionManager Instance{
		get{ return instance; }
	}
	

	public Fader fader;

	public void PlayButtonSound(){
		if (AudioManager.Instance) AudioManager.Instance.PlaySFX (eSFX.BUTTON_PRESS);
	}

	void Awake(){
		if (instance != null && instance != this) {
			// destroy any other singleton object of this class
			Destroy(this.gameObject);  
			return;
		} else instance = this;
	}

	void Start(){
		fader.FadeIn ();
		fader.OnFadeOutFinished += GoToGameScene;
	}

	public void FadeOut(){
		fader.FadeOut ();
	}

	void GoToGameScene(){
		fader.OnFadeOutFinished -= GoToGameScene;
		SceneManager.LoadScene ("SceneGame");
	}
}