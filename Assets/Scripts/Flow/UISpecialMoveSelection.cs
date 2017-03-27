using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpecialMoveSelection : MonoBehaviour {
	public static UISpecialMoveSelection Instance;
	
	public Text Title;
	public Text[] SpecialMove_Details = new Text[2];
	public GameObject UIContent ;
	public GameObject Scroll_Content ;
	public SpecialMoveSO[] SpecialMoves = new SpecialMoveSO[2];
	
	public int SelectedIndex = 0;
	float x, distance;
	
	void Awake(){
		Instance = this;
	}
	
	public void Show(){
		Title.text = "Special Move Selection";
		UIContent.SetActive(true);
		ShowDetails();
	}

	public void hide(){
		UIContent.SetActive(false);
	}

	public void OnBeginDrag(){
		x = Input.mousePosition.x;
		distance = Scroll_Content.transform.position.x - x;
	}
	public void OnDrag(){
		float temp = Input.mousePosition.x;
		Scroll_Content.transform.position = new Vector3 (temp + distance, Scroll_Content.transform.position.y, Scroll_Content.transform.position.z);
	}

	public void OnEndDrag(){
		float xx = Scroll_Content .GetComponent<RectTransform>().anchoredPosition.x;

		if (xx >= 200 || (xx < 200 && xx >= 0)) {
			Scroll_Content.GetComponent<RectTransform>().anchoredPosition = new Vector2 (200, 0);
			SelectedIndex = 0;
		} else if ((xx < 0 && xx > -200) || xx <= -200) {
			Scroll_Content.GetComponent<RectTransform>().anchoredPosition = new Vector2 (-200, 0);
			SelectedIndex = 1;
		}
		ShowDetails();
	}
	
	void ShowDetails(){
		SpecialMove_Details[0].text = "Name = "+SpecialMoves[SelectedIndex].specialMoveName;
		SpecialMove_Details[1].text = "Enhance = "+SpecialMoves[SelectedIndex].specialMoveType;
	}
	
	public void ButtonSelect_OnClick(){
		PlayerDataController.Instance.SetSpecialMove(SpecialMoves[SelectedIndex]);
		UIContent.SetActive(false);
		UIPreBattleResult.Instance.Show();
	}
	
	public void ButtonBack_OnClick(){
		UIContent.SetActive(false);
		UISupportSelections.Instance.Show();
	}
}
