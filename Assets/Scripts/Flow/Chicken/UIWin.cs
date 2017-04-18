using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIWin : MonoBehaviour {

	public Text textPayout,
				textMultiplier,
				textFinalPayout;

	string tempSceneName;


	void OnEnable(){
		ScenePayoutManager.Instance.fader.OnFadeOutFinished += ButtonClick;
		InitDetails ();
	}

	void InitDetails(){
//		textPayout.text = 
		textMultiplier.text = PlayerChickenDataController.Instance.Multiplier.ToString ();
//		int finalPayout = Mathf.FloorToInt(/*get data nya*/ * PlayerChickenDataController.Instance.Multiplier);
	}

	public void ButtonOnClick(string sceneName){
		tempSceneName = sceneName;
	}

	void ButtonClick(){
		ScenePayoutManager.Instance.fader.OnFadeOutFinished -= ButtonClick;
		SceneManager.LoadScene (tempSceneName);
	}
}
