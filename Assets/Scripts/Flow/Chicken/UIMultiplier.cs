using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMultiplier : MonoBehaviour {

	public Text[] textDigit = new Text[3];
	int[] iDigit = new int[3];

	void Start(){
		InitValue();
	}

	void InitValue(){
		iDigit[0] = 2;
		iDigit[1] = iDigit[2] = 0;
		for(int i = 0; i <textDigit.Length; i++) textDigit[i].text = iDigit[i].ToString();
	}

	void ChangeValue(int index, int value){
		if(index == 0){
			if (iDigit[index] == 2 && value == -1) iDigit[index] = 9;
			else if (iDigit[index] == 9 && value == 1)iDigit[index] = 2;
			else iDigit[index] += value;
		}else{
			if (iDigit[index] == 0 && value == -1) iDigit[index] = 9;
			else if (iDigit[index] == 9 && value == 1)iDigit[index] = 0;
			else iDigit[index] += value;
		}

		textDigit[index].text = iDigit[index].ToString();
	}

	public void ButtonUpOnClick(int index){
		AudioManager.Instance.PlaySFX (eSFX.BUTTON_PRESS);
		ChangeValue(index,1);
	}
	public void ButtonDownOnClick(int index){
		AudioManager.Instance.PlaySFX (eSFX.BUTTON_PRESS);
		ChangeValue(index,-1);
	}

	public void BUttonOKOnClick(){
		AudioManager.Instance.PlaySFX (eSFX.BUTTON_PRESS);
		string temp = iDigit[0].ToString() +"."+ iDigit[1].ToString() + iDigit[2].ToString();
//		PlayerPrefs.SetFloat("Multiplier",float.Parse(temp));
		PlayerChickenDataController.Instance.Multiplier = float.Parse (temp);
	}

	public void ButtonBackOnClick(){AudioManager.Instance.PlaySFX (eSFX.BUTTON_PRESS);}
}
