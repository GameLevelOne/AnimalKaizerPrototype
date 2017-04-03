using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour {
	void Awake()
	{
		Application.targetFrameRate = 30;
	}

	void OnGUI()
	{
		GUI.Label (new Rect(10,0,100,50),"FPS: "+ (int) (1.0f / Time.smoothDeltaTime));
	}
		
}
