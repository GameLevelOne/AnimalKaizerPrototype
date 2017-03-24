using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISupportSelections : MonoBehaviour {
	public static UISupportSelections Instance;
	
	public Text Title;
	public Text[] Support_Details = new Text[4];
	public GameObject UIContent ;
	public GameObject Scroll_Content ;
	public SupportSO[] Supports = new SupportSO[2];
	public GameObject PlayerData;
	
	public int SelectedIndex = 0;
	float x, distance;

	void Awake(){
		Instance = this;
	}
	
	public void Show(){
		Title.text = "Support Selection";
		UIContent.SetActive(true);
		ShowDetails();
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
		Support_Details[0].text = "Name = "+Supports[SelectedIndex].supportName;
		Support_Details[1].text = "Enhance = "+Supports[SelectedIndex].supportEnhance;
		Support_Details[2].text = "Focus = "+Supports[SelectedIndex].supportFocus.ToString();
		Support_Details[3].text = "Defence = "+Supports[SelectedIndex].supportDefense.ToString();
	}
	
	public void ButtonSelect_OnClick(){
		PlayerData.GetComponent<Support>().supportSO = Supports[SelectedIndex];
		UIContent.SetActive(false);
		UISpecialMoveSelection.Instance.Show();
	}
	
	public void ButtonBack_OnClick(){
		UIContent.SetActive(false);
		UICharacterSelections.Instance.Show();
	}
}
