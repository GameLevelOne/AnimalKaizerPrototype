using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataController : MonoBehaviour {
	private static PlayerDataController _instance;

    public EnemyListSO enemyList;

    public Character playerChar,enemyChar;

	[SerializeField]
	private int hasil;

	RectTransform t;

	void Awake(){
        if (_instance == null)
        {
			_instance = this;
        }
		else if (_instance!=this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        //SceneManager.LoadScene("Scene Title");
	}

	public static PlayerDataController Instance
	{
		get {
			return _instance;
		}
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
	public void Fight()
	{
		
//		t.anchoredPosition = new 
//		p1.Attack ();
//		p2.Hit ();
	}
}
