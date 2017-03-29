using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataController : MonoBehaviour {
	public static PlayerDataController Instance;

    public EnemyListSO enemyList;

    public Character playerChar,enemyChar;

	void Awake(){
		Instance = this;
		DontDestroyOnLoad(gameObject);
		SceneManager.LoadScene("Scene Title");

	}

	public void ClearData(){
		GetComponent<Character>().charData = null;
		GetComponent<Support>().supportSO = null;
		GetComponent<SpecialMove>().specialMoveSO = null;
	}

	public void SetCharacter(Character p1){
        playerChar = p1;
    }
	public void SetSupport(Support p1Support){
        playerChar.support = p1Support;
	}
	public void SetSpecialMove(SpecialMove p1SpMove){
        playerChar.specialMove = p1SpMove;
	}
    public void SetEnemyCharacter(Character enemy) {
        enemyChar = enemy;
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
