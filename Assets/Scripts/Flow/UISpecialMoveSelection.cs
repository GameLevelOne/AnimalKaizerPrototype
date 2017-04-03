﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpecialMoveSelection : MonoBehaviour {
	public static UISpecialMoveSelection Instance;
	
	public Image Title;
	public Sprite TitleSource;
	public Text[] SpecialMove_Details = new Text[3];
	public GameObject UIContent ;
	public GameObject Scroll_Content ;
	public SpecialMoveSO[] SpecialMoves = new SpecialMoveSO[2];
	
	public int SelectedIndex = 0;
	float x, distance;
	
	void Awake(){
		Instance = this;
	}
	
	public void Show(){
		Title.sprite = TitleSource;
		UIContent.SetActive(true);
		ShowDetails();
	}

	public void hide(){
		UIContent.SetActive(false);
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
		float xx = Scroll_Content .GetComponent<RectTransform>().anchoredPosition.x;

		if (xx >= 200 || (xx < 200 && xx >= 50)) {
//			Scroll_Content.GetComponent<RectTransform>().anchoredPosition = new Vector2 (200, 0);
			StartCoroutine(_SmoothMove(Scroll_Content.GetComponent<RectTransform>().anchoredPosition,new Vector2 (200,0),0.2f));
			SelectedIndex = 0;
		} else if ((xx < 50 && xx > -300) || xx <= -300) {
//			Scroll_Content.GetComponent<RectTransform>().anchoredPosition = new Vector2 (-200, 0);
			StartCoroutine(_SmoothMove(Scroll_Content.GetComponent<RectTransform>().anchoredPosition,new Vector2 (-300,0),0.2f));
			SelectedIndex = 1;
		}
		ShowDetails();
	}
	
	void ShowDetails(){
		SpecialMove_Details[0].text = "NAME : "+SpecialMoves[SelectedIndex].specialMoveName;
		SpecialMove_Details[1].text = "TYPE : "+SpecialMoves[SelectedIndex].specialMoveType.ToString();
		SpecialMove_Details[2].text = "POWER : "+SpecialMoves[SelectedIndex].specialMovePower.ToString();
	}
	
	public void ButtonSelect_OnClick(){
        SpecialMove p1SpMove;

        p1SpMove = new SpecialMove(SpecialMoves[SelectedIndex]);
        PlayerDataController.Instance.SetSpecialMove(p1SpMove);

		UIContent.SetActive(false);
		UIPreBattleResult.Instance.Show();
	}
	
	public void ButtonBack_OnClick(){
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
