using UnityEngine.UI;
using UnityEngine;

public class UIChickenConfirmation : MonoBehaviour {

	public Text textChickenName,
				textChickenHP,
				textChickenPower,
				textChickenSPMove,
				textChickenPrice;

	void OnEnable(){
		ShowChickenDetails ();
	}

	void ShowChickenDetails(){
		textChickenName.text = PlayerChickenDataController.Instance.PlayerChicken.charData.charName;
		textChickenHP.text = PlayerChickenDataController.Instance.PlayerChicken.charData.charHealth.ToString();
		textChickenPower.text = PlayerChickenDataController.Instance.PlayerChicken.charData.charPower.ToString();
//		textChickenSPMove.text = PlayerChickenDataController.Instance.PlayerChicken.charData.charSPMove;
//		textChickenPrice.text = PlayerChickenDataController.Instance.PlayerChicken.charData.charPrice;
	}

	public void ButtonOKOnClick(){AudioManager.Instance.PlaySFX (eSFX.BUTTON_PRESS);}
	public void ButtonBackOnClick(){AudioManager.Instance.PlaySFX (eSFX.BUTTON_PRESS);}
}
