using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPreBattleVS : MonoBehaviour {
	public static UIPreBattleVS Instance;

	public Image
	Img_Player_Character,
	Img_Player_Support,
	Img_Player_SpecialMove,

	Img_Enemy_Character,
	Img_Enemy_Support,
	Img_Enemy_SpecialMove;

	public Text 
	Text_PlayerChar_Name,
	Text_PlayerChar_Power,
	Text_PlayerChar_Health,
	Text_PlayerChar_Type,

	Text_EnemyChar_Name,
	Text_EnemyChar_Power,
	Text_EnemyChar_Health,
	Text_EnemyChar_Type;

	public GameObject UIContent;
	public EnemyListSO EnemyList;

	Character Enemy;

	void Awake(){
		Instance = this;
	}

	public void Show(){
        Enemy = EnemyList.GetRandomEnemy();
        PlayerDataController.Instance.SetEnemyCharacter(Enemy);

		//images
		Img_Player_Character.sprite 	= UIPreBattleResult.Instance.Img_Thumbnails[0].sprite;
		Img_Player_Support.sprite 		= UIPreBattleResult.Instance.Img_Thumbnails[1].sprite;
		Img_Player_SpecialMove.sprite 	= UIPreBattleResult.Instance.Img_Thumbnails[2].sprite;
		Img_Enemy_Character.sprite 		= UIPreBattleResult.Instance.Spr_Characters		[UIPreBattleResult.Instance.getCharIndex		(Enemy.charData.charName)];
		Img_Enemy_Support.sprite 		= UIPreBattleResult.Instance.Spr_Supports		[UIPreBattleResult.Instance.getSupportIndex		(Enemy.support.supportSO.supportName)];
		Img_Enemy_SpecialMove.sprite 	= UIPreBattleResult.Instance.Spr_SpecialMoves	[UIPreBattleResult.Instance.getSpecialMoveIndex	(Enemy.specialMove.specialMoveSO.specialMoveName)];

		//texts
		Text_PlayerChar_Name.text 	= UIPreBattleResult.Instance.Text_Detail_Character_Name.text;
		Text_PlayerChar_Power.text 	= UIPreBattleResult.Instance.Text_Detail_Character_Power.text;
		Text_PlayerChar_Health.text = UIPreBattleResult.Instance.Text_Detail_Character_Health.text;
		Text_PlayerChar_Type.text 	= UIPreBattleResult.Instance.Text_Detail_Character_Type.text;
		Text_EnemyChar_Name.text 	= "NAME : "		+ Enemy.charData.charName;
		Text_EnemyChar_Power.text 	= "POWER : "	+ Enemy.charData.charPower.ToString();
		Text_EnemyChar_Health.text 	= "HEALTH : "	+ Enemy.charData.charHealth.ToString();
		Text_EnemyChar_Type.text 	= "TYPE : "		+ Enemy.charData.charType.ToString();

		UIContent.SetActive(true);
	}

	public void hide(){
		UIContent.SetActive(false);
	}


}