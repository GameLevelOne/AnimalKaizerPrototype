using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIChickenSelection : MonoBehaviour {

	public Character[] chickens;
	public Text[] textChickenPrices;
	public Fader fader;

	void Start(){
		fader.FadeIn ();
	}

	void OnEnable(){
		InitChickenData ();
	}

	void InitChickenData(){
		for (int i = 0; i < chickens.Length; i++) {
//			textChickenPrices [i].text = chickens [i].charData.charPrice;
		}
	}

	public void ButtonChickenOnClick(int index){
		AudioManager.Instance.PlaySFX (eSFX.BUTTON_PRESS);
		//get sprite of the object you select
		Sprite tempSprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image> ().sprite;
		PlayerChickenDataController.Instance.PlayerChickenSprite = tempSprite;
		PlayerChickenDataController.Instance.PlayerChicken = chickens[index];
	}
}
