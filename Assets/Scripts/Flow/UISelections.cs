using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelections : MonoBehaviour {
	public UnityEngine.UI.Text Text_Name ;
	public UnityEngine.UI.Text Text_HP ;
	public UnityEngine.UI.Text Text_Attack ;


	int SelectedIndex = 0;

	public static UISelections Instance;
	public GameObject Content_Character;
	
	public CharacterSO[] Characters = new CharacterSO[2];
	
	CharacterSO SelectedCharacter;
	
	float x, distance;

	void Start(){
		ShowDetails();
	}

	public void OnBeginDrag(){
		x = Input.mousePosition.x;
		distance = Content_Character.transform.position.x - x;

	}
	public void OnDrag(){
		float temp = Input.mousePosition.x;
		Content_Character.transform.position = new Vector3 (temp + distance, Content_Character.transform.position.y, Content_Character.transform.position.z);

	}

	public void OnEndDrag(){
		float xx = Content_Character.GetComponent<RectTransform>().anchoredPosition.x;

		if (xx >= 200 || (xx < 200 && xx >= 0)) {
			Content_Character.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (200, 0);
			SelectedIndex = 0;
		} else if ((xx < 0 && xx > -200) || xx <= -200) {
			Content_Character.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-200, 0);
			SelectedIndex = 1;
		}
		ShowDetails();
	}

	void ShowDetails(){
		Text_Name.text = "Name = "+Characters[SelectedIndex].charName;
		Text_HP.text = "Healh = "+Characters[SelectedIndex].charHealth.ToString();
		Text_Attack.text = "Power = "+Characters[SelectedIndex].charPower.ToString();
	}

	
	public void ButtonSelect_OnClick(){
		SelectedCharacter = Characters[SelectedIndex];
	}
}
