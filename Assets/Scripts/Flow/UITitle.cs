using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UITitle : MonoBehaviour {
    //public Image blackScreen;
	public Fader fader;
    
    void Start()
    {
//        StartCoroutine(FadeTo(1, 0, false));

		fader.FadeIn ();
		AudioManager.Instance.PlayBGM(eBGM.MENU);
    }

	public void OnTapAnywhere(){
		AudioManager.Instance.PlaySFX(eSFX.BUTTON_START);
		fader.FadeOut ();
		fader.OnFadeOutFinished += FinishedFadeOut;

//        StartCoroutine(FadeTo(0, 1, true));
    }

	void FinishedFadeOut()
	{
		fader.OnFadeOutFinished -= FinishedFadeOut;
		SceneManager.LoadScene("SceneSelectionNew");
	}

//    IEnumerator FadeTo(float start,float end,bool changeScene)
//    {
//        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 2)
//        {
//            Color newColor = new Color(0, 0, 0, Mathf.Lerp(start, end, t));
//            blackScreen.color = newColor;
//            yield return null;
//        }
//        if (changeScene) {
//            yield return new WaitForSeconds(2);
//            SceneManager.LoadScene("Scene Selection");
//        }
//    }

}
