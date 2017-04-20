using UnityEngine;
using UnityEngine.UI;

public class UIChickenConfirmation : MonoBehaviour {
	public Text textChickenName,
				textChickenPrice,
				textChickenHealth,
				textChickenPower,
				textChickenSkill;

	public Image imageChicken;

	void OnEnable(){
		ShowChickenDetails ();
	}

	void ShowChickenDetails(){
		CharacterSO playerChicken = PlayerChickenDataController.Instance.PlayerChicken.charData;

		//skills
		string tempAttackData = string.Empty;
		int totalAttackData = playerChicken.charAttackData.Length;
		for (int i = 0; i < totalAttackData; i++) {
			string temp = playerChicken.charAttackData [i].attackName;
			if (i != totalAttackData - 1) temp += ", ";
			tempAttackData += temp;
		}

		textChickenName.text   = playerChicken.charName;
		textChickenPrice.text  = "$ " + playerChicken.charPrice.ToString ();

		textChickenHealth.text = "Health : "+ playerChicken.charHealth.ToString();
		textChickenPower.text  = "Power : " + playerChicken.charPower.ToString();
		textChickenSkill.text  = "Skills : "+ tempAttackData;

		imageChicken.sprite = PlayerChickenDataController.Instance.PlayerChickenSprite;
	}
}