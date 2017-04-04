using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Payout : MonoBehaviour {

	public int payoutThreshold = 200;

	public Text payoutText;
	public Button addButton;

	void OnEnable () {
		int payout = PlayerPrefs.GetInt ("PlayerPayout",200);
		payoutText.text = payout.ToString () + "%";
	}

	public void InitPayout()
	{
		PlayerPrefs.DeleteKey ("PlayerPayout");
	}
	public void AddPayout(int addPayout)
	{
        AudioManager.Instance.PlaySFX(eSFX.COIN);
		int payout = PlayerPrefs.GetInt ("PlayerPayout",200);
		if (payout < payoutThreshold) {
			payout += addPayout;
			PlayerPrefs.SetInt ("PlayerPayout",payout);
			payoutText.text = payout.ToString () + "%";
			if (payout >= payoutThreshold) {
				addButton.interactable = false;
			}
		}
	}
}
