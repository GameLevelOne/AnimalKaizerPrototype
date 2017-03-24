using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterSelections : MonoBehaviour {
	public static UICharacterSelections Instance;
	
	public Text Title;
	public Text[] Character_Details = new Text[4];
	public GameObject UIContent ;
	public GameObject Scroll_Content ;
	public CharacterSO[] Characters = new CharacterSO[2];
	public GameObject PlayerData;
	
	
	public int SelectedIndex = 0;
	float x, distance;

	void Awake(){
		Instance = this;
	}
	
	void Start(){
		Title.text = "Character Selection";
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
		float xx = Scroll_Content.GetComponent<RectTransform>().anchoredPosition.x;

		if (xx >= 200 || (xx < 200 && xx >= 0)) {
			Scroll_Content.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (200, 0);
			SelectedIndex = 0;
		} else if ((xx < 0 && xx > -200) || xx <= -200) {
			Scroll_Content.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-200, 0);
			SelectedIndex = 1;
		}
		ShowDetails();
	}

	void ShowDetails(){
		Character_Details[0].text = "Name = "+Characters[SelectedIndex].charName;
		Character_Details[1].text = "Health = "+Characters[SelectedIndex].charHealth.ToString();
		Character_Details[2].text = "Power = "+Characters[SelectedIndex].charPower.ToString();
		Character_Details[3].text = "Element = "+Characters[SelectedIndex].charType;
	}
	
	public void ButtonSelect_OnClick(){
		PlayerData.GetComponent<Character>().charData = Characters[SelectedIndex];
		UIContent.SetActive(false);
		UISupportSelections.Instance.Show();
	}
}
