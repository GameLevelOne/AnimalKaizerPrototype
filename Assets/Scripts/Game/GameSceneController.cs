using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum eCurrentGameState {
    Countdown = 0,
    RandomizeAttackType,
    RandomizePowerType,
    Battle
}

public class GameSceneController : MonoBehaviour {

    public GameObject panelCountdown;

    public Text timer;
    public Text p1AttackType;
    public Text p2AttackType;
    public Text p1Power;
    public Text p2Power;

    private string[] attackTypeList = new string[3] { "Q", "T", "S" };
    private string[] powerList = new string[5] { "10", "20", "30", "40", "50" };

    private bool isWaiting = false;

    private float waitTimer = 0f;

    private int p1CurrAttackTypeIdx = 0;

    private eCurrentGameState currGameState = eCurrentGameState.Countdown;

	// Use this for initialization
	void Start () {
        //countdown
        StartCoroutine(StartCountdown());

	}
	
	// Update is called once per frame
	void Update () {

        //random attack type
        if (currGameState == eCurrentGameState.RandomizeAttackType)
        {
            RandomizeAttackPower(attackTypeList, p1AttackType);
        }
        else if(currGameState == eCurrentGameState.RandomizePowerType){
            RandomizeAttackPower(powerList, p1Power);
        }

        

        if (Input.GetMouseButtonDown(0)) {
            if (currGameState == eCurrentGameState.RandomizeAttackType)
            {
                isWaiting = true;
            }
            else if(currGameState == eCurrentGameState.RandomizePowerType){
                isWaiting = true;
            }
        }

        if (isWaiting) {
            waitTimer += Time.deltaTime;
        }

        if (waitTimer > 1) {
            waitTimer = 0;
            if (currGameState == eCurrentGameState.RandomizeAttackType)
            {
                //show enemy's attack type then switch to randomize power
                p2AttackType.text = attackTypeList[Random.Range(0, (attackTypeList.Length - 1))];
                currGameState = eCurrentGameState.RandomizePowerType;
            }
            else if(currGameState == eCurrentGameState.RandomizePowerType){
                //show enemy's power
                p2Power.text = powerList[Random.Range(0, (powerList.Length - 1))];
                currGameState = eCurrentGameState.Battle;
            }

            isWaiting = false;
        }

	}

    IEnumerator StartCountdown() {
        yield return new WaitForSeconds(2);
        timer.text = "3";
        yield return new WaitForSeconds(1);
        timer.text = "2";
        yield return new WaitForSeconds(1);
        timer.text = "1";
        yield return new WaitForSeconds(1);
        timer.text = "START";
        yield return new WaitForSeconds(1);
        panelCountdown.SetActive(false);
        currGameState = eCurrentGameState.RandomizeAttackType;
    }

    void RandomizeAttackPower(string[] currList,Text currTarget) {
        currTarget.text = currList[p1CurrAttackTypeIdx];

        if (p1CurrAttackTypeIdx == (currList.Length - 1))
        {
            p1CurrAttackTypeIdx=0;
        }
        else
        {
            p1CurrAttackTypeIdx++;
        }
    }
}
