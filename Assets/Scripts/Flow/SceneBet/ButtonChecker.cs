using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChecker : MonoBehaviour {

	public int coinThreshold;

	void Start () {
		CheckCoinState ();
	}
	
	public void CheckCoinState () {
		int coin = PlayerPrefs.GetInt ("PlayerCoin", 5000);
		if (coin < coinThreshold) {
			this.GetComponent<Button>().interactable = false;
		} else {
			this.GetComponent<Button>().interactable = true;
		}
	}
}
