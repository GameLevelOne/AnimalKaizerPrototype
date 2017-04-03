using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPreBattleResult : MonoBehaviour {
public static UIPreBattleResult Instance;
	
	public GameObject Title;

	public Sprite[] Spr_Characters = new Sprite[2];
	public Sprite[] Spr_Supports = new Sprite[2];
	public Sprite[] Spr_SpecialMoves = new Sprite[2];

	public Text
	Text_Detail_Character_Name,
	Text_Detail_Character_Power,
	Text_Detail_Character_Health,
	Text_Detail_Character_Type,
	Text_Detail_Support_Name,
	Text_Detail_SpecialMove_Name;

	public Image[] Img_Thumbnails = new Image[3];
	
	public GameObject Content;
	
	void Awake(){
		Instance = this;
	}
	
	public void Show(){
		Title.SetActive (false);
		Content.SetActive(true);
		AssignAllPlayerData();
	}

	public void hide(){
		Content.SetActive(false);
	}

	void AssignAllPlayerData(){
        string charName = PlayerDataController.Instance.playerChar.charData.charName;
        string charSupportName = PlayerDataController.Instance.playerChar.support.supportSO.supportName;
		string charSpecialMoveName = PlayerDataController.Instance.playerChar.specialMove.specialMoveSO.specialMoveName;

		//images
		Img_Thumbnails[0].sprite = Spr_Characters[getCharIndex(charName)];
		Img_Thumbnails[1].sprite = Spr_Supports[getSupportIndex(charSupportName)];
		Img_Thumbnails[2].sprite = Spr_SpecialMoves[getSpecialMoveIndex(charSpecialMoveName)];

		//details (text)
		Text_Detail_Character_Name.text = charName;
		Text_Detail_Support_Name.text = charSupportName;
		Text_Detail_SpecialMove_Name.text = charSpecialMoveName; 
		Text_Detail_Character_Power.text = PlayerDataController.Instance.playerChar.charData.charPower.ToString(); 
		Text_Detail_Character_Health.text = PlayerDataController.Instance.playerChar.charData.charHealth.ToString();
		Text_Detail_Character_Type.text = PlayerDataController.Instance.playerChar.charData.charType.ToString();

	}

	int getCharIndex(string name){
		int temp = -1;
		switch (name){
		case "Genderuwo": temp = 0; break;
		case "Kunti"	: temp = 1; break;
		}
		return temp;
	}

	int getSupportIndex(string name){
		int temp = -1;
		switch (name){
		case "Pocong"		: temp = 0; break;
		case "Suster Ngesot": temp = 1; break;
		}
		return temp;
	}
	int getSpecialMoveIndex(string name){
		int temp = -1;
		switch (name){
		case "Mana Kepalaku": temp = 0; break;
		case "Serbuan Tuyul": temp = 1; break;
		}
		return temp;
	}


	public void ButtonOK_OnClick(){
		Content.SetActive(false);
		UIPreBattleVS.Instance.Show();
	}
	
	public void ButtonBack_OnClick(){
		Title.SetActive (true);
		Content.SetActive(false);
		UISpecialMoveSelection.Instance.Show();
	}
}
