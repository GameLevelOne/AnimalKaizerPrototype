using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISupportSelections : UICharacterSelections {
	public static UISupportSelections Instance;
	
	public Text[] Support_Details = new Text[4];
	public SupportSO[] Supports = new SupportSO[2];
	
	public int SelectedIndex = 0;
	float x, distance;

	public UICharacterSelections nextPanel;
	public GameObject prevPanel;


	new void Start()
	{
	}

	public new void Show(){
		Title.sprite = TitleSource;
		UIContent.SetActive(true);
		ShowDetails("NAME: ","ENHANCE: ","FOCUS: ","DETAILS: ");
	}

	public void hide(){
		UIContent.SetActive(false);
	}


	public void ButtonSelect_OnClick(){
		AudioManager.Instance.PlaySFX(eSFX.BUTTON_PRESS);

		Support p1Support;

        p1Support = new Support(Supports[SelectedIndex]);
        PlayerDataController.Instance.SetSupport(p1Support);

		UIContent.SetActive(false);
		UISpecialMoveSelection.Instance.Show();
	}
	
	public void ButtonBack_OnClick(){
		AudioManager.Instance.PlaySFX(eSFX.BUTTON_PRESS);

		UIContent.SetActive(false);
		UICharacterSelections.Instance.Show();

	}
	Text[] Blabla()
	{
		if (Support_Details == null) {
			//blalblal
			return Support_Details;
		}

		//sabdsajdbasdasndkl
	}
}
