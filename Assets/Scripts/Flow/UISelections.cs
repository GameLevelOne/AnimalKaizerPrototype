using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelections : MonoBehaviour {
	public static UISelections Instance;
	public GameObject Content_Character;
	float x, distance;
	public void OnBeginDrag(){
		x = Input.mousePosition.x;
		print (Input.mousePosition.x);
		print (Content_Character.transform.position.x);

	}
	public void OnDrag(){
		
		distance = Content_Character.transform.position.x - x;
//		if (Content_Character.GetComponent<RectTransform> ().anchoredPosition.x > 400 || Content_Character.GetComponent<RectTransform> ().anchoredPosition.x <= -400) {
//			if(Content_Character.GetComponent<RectTransform> ().anchoredPosition.x > 400) Content_Character.GetComponent<RectTransform> ().anchoredPosition = new Vector2(400,0);
//			if(Content_Character.GetComponent<RectTransform> ().anchoredPosition.x < -400) Content_Character.GetComponent<RectTransform> ().anchoredPosition = new Vector2(-400,0);
//			return;
//		}
//		else {
			print ("GO");
			Content_Character.transform.position = new Vector3 (x + distance, Content_Character.transform.position.y, Content_Character.transform.position.z);
//		}
	}

	public void OnEndDrag(){
		float x = Content_Character.GetComponent<RectTransform>().anchoredPosition.x;

		if (x >= 400 || (x < 400 && x >= 200)) {
			Content_Character.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (400, 0);
		} else if (x < 200 && x >= -200) {
			Content_Character.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, 0);
		} else if ((x < -200 && x > -400) || x <= -400) {
			Content_Character.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-400, 0);
		}
	}

}
