using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelections : MonoBehaviour {
	public UnityEngine.UI.Text Text_Name ;
	public UnityEngine.UI.Text Text_HP ;
	public UnityEngine.UI.Text Text_Attack ;
	public UnityEngine.UI.Text Text_Ability ;

	string[] sName = new string[]{"Suster Ngesot","Tuyul","Pocong"};
	string [] sHP = new string[]{"1000","2000","3000"};
	string[] sAttack = new string[]{"100","200","300"};
	string[] sAbility = new string[]{"ngesot","nyolong","loncat"};
	int SelectedIndex = 0;

	public static UISelections Instance;
	public GameObject Content_Character;
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

		if (xx >= 400 || (xx < 400 && xx >= 200)) {
			Content_Character.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (400, 0);
			SelectedIndex = 0;
		} else if (xx < 200 && xx >= -200) {
			Content_Character.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
			SelectedIndex = 1;
		} else if ((xx < -200 && xx > -400) || xx <= -400) {
			Content_Character.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-400, 0);
			SelectedIndex = 2;
		}
		ShowDetails();
	}

	void ShowDetails(){
		Text_Name.text = "Name : "+ sName[SelectedIndex];
		Text_Attack.text = "Attack : "+sAttack[SelectedIndex];
		Text_HP.text = "HP : "+sHP[SelectedIndex];
		Text_Ability.text = "Ability : "+sAbility[SelectedIndex];
	}

}
