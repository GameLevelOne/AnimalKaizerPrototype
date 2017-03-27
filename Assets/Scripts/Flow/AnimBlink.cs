using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimBlink : MonoBehaviour {

	float t = 0;
	
	void FixedUpdate(){
		t += Time.deltaTime;
		if (t >= 0 && t < 0.5f) {
			GetComponent<UnityEngine.UI.Text> ().color = new Color (0, 0, 0, 1);
		} else if (t >= 0.5f && t < 1) {
			GetComponent<UnityEngine.UI.Text> ().color = new Color (0, 0, 0, 0);
		}

		if (t >= 1) {
			t = 0;
		}
	}
}
