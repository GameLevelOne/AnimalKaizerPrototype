using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCoin : MonoBehaviour {

	public Text coinAmount;

	void Start () {
		int coin = PlayerPrefs.GetInt ("PlayerCoin", 5000);
		coinAmount.text = coin.ToString ("N0");
	}
	public void SetCoin(int coin)
	{
		coinAmount.text = coin.ToString ("N0");
		PlayerPrefs.SetInt ("PlayerCoin",coin);
	}
	public void ModCoin(int coinMod)
	{
		int coin = PlayerPrefs.GetInt ("PlayerCoin", 5000);
		coin += coinMod;
		coinAmount.text = coin.ToString ("N0");
		PlayerPrefs.SetInt ("PlayerCoin",coin);
        AudioManager.Instance.PlaySFX(eSFX.COIN);

    }
}
