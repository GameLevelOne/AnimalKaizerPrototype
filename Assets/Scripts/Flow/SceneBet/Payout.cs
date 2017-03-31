using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Payout : MonoBehaviour {

	public int payoutThreshold = 200;

	public Text payoutText;
	public Button addButton;

	void OnEnable () {
		int payout = PlayerPrefs.GetInt ("PlayerPayout",100);
		payoutText.text = payout.ToString () + "%";
	}

	public void InitPayout()
	{
		PlayerPrefs.DeleteKey ("PlayerPayout");
	}
	public void AddPayout(int addPayout)
	{
		int payout = PlayerPrefs.GetInt ("PlayerPayout",100);
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
