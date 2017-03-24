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
    private int p2CurrAttackTypeIdx = 0;
    private int p1CurrPowerIdx = 0;
    private int p2CurrPowerIdx = 0;
    private int currRollIdx = 0;

    private eCurrentGameState currGameState = eCurrentGameState.Countdown;

	// Use this for initialization
	void Start () {
        //countdown
        StartCoroutine(StartCountdown());

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            if (currGameState == eCurrentGameState.RandomizeAttackType)
            {
                isWaiting = true;
                Debug.Log("p1 attack type:" + attackTypeList[p1CurrAttackTypeIdx]);
            }
            else if (currGameState == eCurrentGameState.RandomizePowerType)
            {
                isWaiting = true;
                Debug.Log("p1 power:" + powerList[p1CurrPowerIdx]);
            }
        }

        //random attack type
        if (!isWaiting)
        {
            //p1
            if (currGameState == eCurrentGameState.RandomizeAttackType)
            {
                Debug.Log("random atk");
                //RandomizeAttackPower(attackTypeList, p1AttackType, p1CurrAttackTypeIdx);
                p1CurrAttackTypeIdx = rollIdx(attackTypeList.Length-1);
                p1AttackType.text = attackTypeList[p1CurrAttackTypeIdx];
            }
            else if (currGameState == eCurrentGameState.RandomizePowerType)
            {
                Debug.Log("random pow");
                p1CurrPowerIdx = rollIdx(powerList.Length-1);
                p1Power.text = powerList[p1CurrPowerIdx];
            }
        } else if (isWaiting){
            //p2
            if (currGameState == eCurrentGameState.RandomizeAttackType)
            {
                p2CurrAttackTypeIdx = rollIdx(attackTypeList.Length-1);
                p2AttackType.text = attackTypeList[p1CurrAttackTypeIdx];
            }
            else if (currGameState == eCurrentGameState.RandomizePowerType)
            {
                p2CurrPowerIdx = rollIdx(powerList.Length-1);
                p2Power.text = powerList[p1CurrAttackTypeIdx];
            }
        }

        if (isWaiting) {
            waitTimer += Time.deltaTime;
        }

        if (waitTimer > 1) {
            waitTimer = 0;
            isWaiting = false;

            if (currGameState == eCurrentGameState.RandomizeAttackType)
            {
                currGameState = eCurrentGameState.RandomizePowerType;

                //show enemy's attack type then switch to randomize power
                //p2CurrAttackTypeIdx = Random.Range(0, (attackTypeList.Length - 1));
                p2AttackType.text = attackTypeList[p2CurrAttackTypeIdx];
                
                Debug.Log("p2 attack type:" + attackTypeList[p2CurrAttackTypeIdx]);
            }
            else if(currGameState == eCurrentGameState.RandomizePowerType){
                currGameState = eCurrentGameState.Battle;

                //show enemy's power
                //p2CurrPowerIdx = Random.Range(0, (powerList.Length - 1));
                p2Power.text = powerList[p2CurrPowerIdx];
                
                Debug.Log("p2 power:" + powerList[p2CurrPowerIdx]);
            }
        }

	}

    IEnumerator StartCountdown() {
        yield return new WaitForSeconds(1);
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

    int rollIdx(int max) {
        //TODO: fix this
        if (currRollIdx == max)
        {
            currRollIdx = 0;
        }
        else
        {
            currRollIdx++;
        }

        return currRollIdx;
    }
}
