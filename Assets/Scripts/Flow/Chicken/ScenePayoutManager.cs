using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePayoutManager : MonoBehaviour {
	static ScenePayoutManager instance = null;
	public static ScenePayoutManager Instance{ get{ return instance; } }

	public Fader fader;

	public GameObject uiWin, uiLose;
	public PlayerCoin playerCoin;

	int tempCondition = 0;

	void Awake(){
		if (instance != null && instance != this) {
			// destroy any other singleton object of this class
			Destroy(this.gameObject);  
			return;
		} else instance = this;
	}

	void Start(){
		if (AudioManager.Instance) AudioManager.Instance.PlayBGM (eBGM.MENU);

		ShowUIWinLose();
		fader.FadeIn();
	}


	void ShowUIWinLose(){
		int tempCondition = PlayerPrefs.GetInt ("PlayerWin");
		if (tempCondition == 1) {
			uiWin.SetActive (true);
			uiLose.SetActive (false);
			uiWin.GetComponent<UIWin> ().InitDetails ();
		}
		else {
			uiWin.SetActive (false);
			uiLose.SetActive (true);
		}
		playerCoin.ModCoin (CalculatePayoutMultiplier (tempCondition));
	}

	public int finalPayout{ 
		get { return CalculatePayoutMultiplier (tempCondition); } 
	}

	int CalculatePayoutMultiplier(int condition){
		float multiplier = PlayerChickenDataController.Instance.Multiplier;
		int playerChickenPrice = PlayerChickenDataController.Instance.PlayerChicken.charData.charPrice;
		print (Mathf.CeilToInt (playerChickenPrice * multiplier));

		int finalPayout = Mathf.CeilToInt (playerChickenPrice * multiplier);

		if (condition > 0) {
			return finalPayout;
		} else {
			return finalPayout * -1;
		}
	}
}
