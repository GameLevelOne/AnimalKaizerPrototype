using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIThankYou : MonoBehaviour {

	public Fader fader;
	public PlayerCoin playerCoin;
	public Text payoutText;

	void Start () {
		Application.targetFrameRate = 60;
		fader.FadeIn ();
		PlayerPrefs.SetInt ("PlayerWin", 0);
//		int payout = PlayerPrefs.GetInt ("PlayerPayout",200);
//		int coin = PlayerPrefs.GetInt ("PlayerCoin", 5000);
//		int playerWin = PlayerPrefs.GetInt ("PlayerWin",0);
//		int totalCoin = playerWin > 0 ? coin + (500 * (payout / 100)) : coin;
//		playerCoin.SetCoin (totalCoin);
//		payoutText.text = "PAYOUT:\n\n"+payout+"%";
	}
	public void NextScene () {
		AudioManager.Instance.PlaySFX(eSFX.BUTTON_PRESS);
		fader.FadeOut ();
		fader.OnFadeOutFinished += FadeFinished;
	}	
	void FadeFinished()
	{
		fader.OnFadeOutFinished -= FadeFinished;
		SceneManager.LoadScene ("SceneTitle");
	}
	public void ButtonPress()
	{
		AudioManager.Instance.PlaySFX(eSFX.BUTTON_PRESS);
	}
}
