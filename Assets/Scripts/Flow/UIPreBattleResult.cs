using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPreBattleResult : MonoBehaviour {
public static UIPreBattleResult Instance;
	
	public Text Title;
	
	public Sprite[] Spr_Characters = new Sprite[2];
	public Sprite[] Spr_Supports = new Sprite[2];
	public Sprite[] Spr_SpecialMoves = new Sprite[2];
	
	public Text[] Text_Details_Characters = new Text[4];
	public Text[] Text_Details_Supports = new Text[4];
	public Text[] Text_Details_SpecialMoves = new Text[2];
	
	public Image[] Img_Thumbnails = new Image[3];
	
	public GameObject Content;
	
	void Awake(){
		Instance = this;
	}
	
	public void Show(){
		Title.text = "Pre Battle";
		Content.SetActive(true);
		AssignAllPlayerData();
	}
	
	void AssignAllPlayerData(){
		//images
		Img_Thumbnails[0].sprite = Spr_Characters[UICharacterSelections.Instance.SelectedIndex];
		Img_Thumbnails[1].sprite = Spr_Supports[UISupportSelections.Instance.SelectedIndex];
		Img_Thumbnails[2].sprite = Spr_SpecialMoves[UISpecialMoveSelection.Instance.SelectedIndex];
		
		for(int i = 0;i<4;i++){
			Text_Details_Characters[i].text = UICharacterSelections.Instance.Character_Details[i].text;
			Text_Details_Supports[i].text = UISupportSelections.Instance.Support_Details[i].text;
			if(i < 2) Text_Details_SpecialMoves[i].text = UISpecialMoveSelection.Instance.SpecialMove_Details[i].text;
		}
	}
}
