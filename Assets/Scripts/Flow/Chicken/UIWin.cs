using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIWin : MonoBehaviour {
	public Text textPayout,
				textMultiplier,
				textFinalPayout;

	string tempSceneName;

	public void InitDetails(){
		ScenePayoutManager.Instance.fader.OnFadeOutFinished += ButtonClick;

		textPayout.text = PlayerChickenDataController.Instance.PlayerChicken.charData.charPrice.ToString("N0");
		textMultiplier.text = PlayerChickenDataController.Instance.Multiplier.ToString ("#.00");
		textFinalPayout.text = "$ "+ScenePayoutManager.Instance.finalPayout.ToString();
	}

	public void ButtonOnClick(string sceneName){
		tempSceneName = sceneName;
	}

	void ButtonClick(){
		ScenePayoutManager.Instance.fader.OnFadeOutFinished -= ButtonClick;
		SceneManager.LoadScene (tempSceneName);
	}
}
