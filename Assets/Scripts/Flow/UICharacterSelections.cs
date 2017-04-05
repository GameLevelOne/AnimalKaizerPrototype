using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterSelections : MonoBehaviour {
	public static UICharacterSelections Instance;
	
	public Image Title;
	public Sprite TitleSource;
	public Text[] Character_Details = new Text[4];
	public GameObject UIContent ;
	public GameObject Scroll_Content ;
	public CharacterSO[] Characters = new CharacterSO[2];

	public Fader fader;

    Character p1Char;
	
	public int SelectedIndex = 0;
	float x, distance;

	void Awake(){
		
		Instance = this;
	}
	
	void Start(){
		Title.sprite = TitleSource;
		fader.FadeIn ();
		Show();
	}
	
	public void Show(){
		UISupportSelections.Instance.hide();
		UISpecialMoveSelection.Instance.hide();
		UIPreBattleResult.Instance.hide();

		UIContent.SetActive(true);
		ShowDetails("NAME: ","HEALTH: ","POWER: ","TYPE: ");
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

		if (xx >= 200 || (xx < 200 && xx >= 50)) {
//			Scroll_Content.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (200, 0);
			StartCoroutine(_SmoothMove(Scroll_Content.GetComponent<RectTransform>().anchoredPosition,new Vector2 (200,0),0.2f));
			SelectedIndex = 0;
		} else if ((xx < 50 && xx > -300) || xx <= -300) {
//			Scroll_Content.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-200, 0);
			StartCoroutine(_SmoothMove(Scroll_Content.GetComponent<RectTransform>().anchoredPosition,new Vector2 (-300,0),0.2f));
			SelectedIndex = 1;
		}
		ShowDetails("NAME: ","HEALTH: ","POWER: ","TYPE: ");
	}

	protected void ShowDetails(string prefixa,string prefixb,string prefixc,string prefixd){
		Character_Details[0].text = prefixa+Characters[SelectedIndex].charName;
		Character_Details[1].text = prefixb+Characters[SelectedIndex].charHealth.ToString();
		Character_Details[2].text = prefixc+Characters[SelectedIndex].charPower.ToString();
		Character_Details[3].text = prefixd+Characters[SelectedIndex].charType.ToString();
	}
	public virtual void HideDetails ()
	{
	}


	public void ButtonSelect_OnClick(){
		//PlayerDataController.Instance.SetCharacter(Characters[SelectedIndex]);
		AudioManager.Instance.PlaySFX(eSFX.BUTTON_PRESS);

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
