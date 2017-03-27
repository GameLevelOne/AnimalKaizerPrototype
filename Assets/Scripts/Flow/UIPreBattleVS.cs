using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPreBattleVS : MonoBehaviour {

	public Text Title;
	public GameObject Player;

	public void Show(){
		Title.text = Player.GetComponent<Character>().charData+" VS. "+"Enemy";
	}
}
