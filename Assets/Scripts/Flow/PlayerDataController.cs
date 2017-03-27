using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataController : MonoBehaviour {
	public static PlayerDataController Instance;

	void Awake(){
		Instance = this;
		DontDestroyOnLoad(gameObject);
		//SceneManager.LoadScene("Scene Title");

	}

	public void ClearData(){
		GetComponent<Character>().charData = null;
		GetComponent<Support>().supportSO = null;
		GetComponent<SpecialMove>().specialMoveSO = null;
	}

	public void SetCharacter(CharacterSO character){
		GetComponent<Character>().charData = character;
	}
	public void SetSupport(SupportSO support){
		GetComponent<Support>().supportSO = support;
	}
	public void SetSpecialMove(SpecialMoveSO specialmove){
		GetComponent<SpecialMove>().specialMoveSO = specialmove;
	}

	public string getCharacterName(){
		return GetComponent<Character>().charData.charName;
	}

	public string getSupportName(){
		return GetComponent<Support>().supportSO.supportName;
	}

	public string getSopecialMoveName(){
		return GetComponent<SpecialMove>().specialMoveSO.specialMoveName;
	}

}
