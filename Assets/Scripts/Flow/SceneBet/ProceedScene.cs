﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProceedScene : MonoBehaviour {

	public void NextScene (string sceneName) {
		SceneManager.LoadScene (sceneName);
	}	
}
