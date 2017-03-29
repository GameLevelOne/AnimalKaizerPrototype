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

    Character p1Char;
	
	public int SelectedIndex = 0;
	float x, distance;

	void Awake(){
		Instance = this;
	}
	
	void Start(){
		Title.text = "Character Selection";
		Show();
	}
	
	public void Show(){
		UISupportSelections.Instance.hide();
		UISpecialMoveSelection.Instance.hide();
		UIPreBattleResult.Instance.hide();

		UIContent.SetActive(true);
		ShowDetails();
	}

	public void OnPointerDown(){
		StopAllCoroutines();
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
//			Scroll_Content.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (200, 0);
			StartCoroutine(_SmoothMove(Scroll_Content.GetComponent<RectTransform>().anchoredPosition,new Vector2 (200,0),0.2f));
			SelectedIndex = 0;
		} else if ((xx < 0 && xx > -200) || xx <= -200) {
//			Scroll_Content.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-200, 0);
			StartCoroutine(_SmoothMove(Scroll_Content.GetComponent<RectTransform>().anchoredPosition,new Vector2 (-200,0),0.2f));
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
		//PlayerDataController.Instance.SetCharacter(Characters[SelectedIndex]);

        p1Char = new Character(Characters[SelectedIndex]);
        PlayerDataController.Instance.SetCharacter(p1Char);
        
        UIContent.SetActive(false);
		UISupportSelections.Instance.Show();
	}

	IEnumerator _SmoothMove(Vector2 startpos, Vector2 endpos, float duration){
		float t = 0;
		while(t <= 1){
			t += Time.deltaTime / duration;
			Scroll_Content.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(startpos,endpos, Mathf.SmoothStep(0,1,t));	
			yield return null;
		}
	}
}
