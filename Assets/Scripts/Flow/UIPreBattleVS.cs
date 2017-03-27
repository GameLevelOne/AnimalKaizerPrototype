using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum eCharacter{
	GENDERUWO = 0,
	KUNTI,
	KOLORIJO,
	POCONG,
	TUYUL,
	SUSTER
}

public class UIPreBattleVS : MonoBehaviour {
	public static UIPreBattleVS Instance;

	public Text Title;

	public Sprite[] Spr_Characters = new Sprite[6];

	public Image
	Img_Player_Character,
	Img_Player_Support,
	Img_Enemy_Character,
	Img_Enemy_Support;

	public Text 
	Text_Player_Name,
	Text_Player_Support,
	Text_Enemy_Name,
	Text_Enemy_Support;

	public GameObject Player, UIContent;
	public EnemyListSO EnemyList;

	eCharacter chara;
	Character Enemy;

	void Awake(){
		Instance = this;
	}

	public void Show(){
		Enemy = EnemyList.GetRandomEnemy();
		Title.enabled = false;
		string player_name = PlayerDataController.Instance.getCharacterName();
		string player_support_name = PlayerDataController.Instance.getSupportName();
		string enemy_name = Enemy.charData.charName;
		string enemy_support_name = Enemy.support.supportSO.supportName;

		Text_Player_Name.text = player_name;
		Text_Player_Support.text = player_support_name;
		Text_Enemy_Name.text = enemy_name;
		Text_Enemy_Support.text = enemy_support_name;

		Img_Player_Character.sprite = Spr_Characters[(int)getCharEnum(player_name)];
		Img_Player_Support.sprite = Spr_Characters[(int)getCharEnum(player_support_name)];
		Img_Enemy_Character.sprite = Spr_Characters[(int)getCharEnum(enemy_name)];
		Img_Enemy_Support.sprite = Spr_Characters[(int)getCharEnum(enemy_support_name)];
		Img_Player_Character.SetNativeSize();
		Img_Player_Support.SetNativeSize();
		Img_Enemy_Character.SetNativeSize();
		Img_Enemy_Support.SetNativeSize();
		UIContent.SetActive(true);
	}

	public void hide(){
		UIContent.SetActive(false);
	}

	eCharacter getCharEnum(string name){
		switch (name){
		case "Genderuwo"	: return eCharacter.GENDERUWO; break;
		case "Kunti"		: return eCharacter.KUNTI; break;
		case "Kolorijo" 	: return eCharacter.KOLORIJO; break;
		case "Pocong" 		: return eCharacter.POCONG; break;
		case "Tuyul" 		: return eCharacter.TUYUL; break;
		case "Suster Ngesot": return eCharacter.SUSTER; break;
		default: return eCharacter.GENDERUWO;
		}
	}
}