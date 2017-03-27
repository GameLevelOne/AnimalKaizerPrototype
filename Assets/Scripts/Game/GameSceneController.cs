using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum eCurrentGameState {
    Countdown = 0,
    RandomizeAttackType,
    RandomizePowerType,
    CompareDamage,
    ApplyDamage,
    EndTurn
}

public class GameSceneController : MonoBehaviour {
    public RouletteTrigger rouletteTrigger;

    public GameObject panelCountdown;

    public Text timer;
    public Text p1AttackType;
    public Text p2AttackType;
    public Text p1Power;
    public Text p2Power;

    public Image p1HPBar;
    public Image p2HPBar;

    public GameObject[] p1RouletteAtkBox = new GameObject[3];
    public GameObject[] p2RouletteAtkBox = new GameObject[3];
    public GameObject[] p1RoulettePowerBox = new GameObject[4];
    public GameObject[] p2RoulettePowerBox = new GameObject[4];

    private Vector3[] p1RouletteAtkBoxStartPos = new Vector3[3];
    private Vector3[] p2RouletteAtkBoxStartPos = new Vector3[3];
    private Vector3[] p1RoulettePowerBoxStartPos = new Vector3[4];
    private Vector3[] p2RoulettePowerBoxStartPos = new Vector3[4];

    private Character p1Char, p2Char;

    private string[] attackTypeList = new string[3] { "Q", "T", "S" };
    private string[] powerList = new string[4] { "20", "30", "40", "50" };

    private string p1CurrAtkType;
    private string p2CurrAtkType;
    private string p1CurrPower;
    private string p2CurrPower;

    private GameObject boxTemp;

    private bool isWaiting = false;
    private bool stopSpinRouletteAtk = true;
    private bool stopSpinRoulettePower = true;

    private float waitTimer = 0f;

    private int p1CurrAttackTypeIdx = 0;
    private int p2CurrAttackTypeIdx = 0;
    private int p1CurrPowerIdx = 0;
    private int p2CurrPowerIdx = 0;
    private int currRollIdx = 0;
    private int currDmg = 0;
    private int drawMultiplier = 1;
    private int p1RoundCount = 0;
    private int p2RoundCount = 0;

    private eCurrentGameState currGameState = eCurrentGameState.Countdown;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 3; i++) {
            p1RouletteAtkBoxStartPos[i] = p1RouletteAtkBox[i].transform.localPosition;
            p2RouletteAtkBoxStartPos[i] = p2RouletteAtkBox[i].transform.localPosition;
        }

        for (int i = 0; i < 4; i++) {
            p1RoulettePowerBoxStartPos[i] = p1RoulettePowerBox[i].transform.localPosition;
            p2RoulettePowerBoxStartPos[i] = p2RoulettePowerBox[i].transform.localPosition;
        }

        p1Char.Life = p1Char.MaxLife;
        p2Char.Life = p2Char.MaxLife;

        //countdown
        StartCoroutine(StartCountdown());

	}
	
	// Update is called once per frame
	void Update () {

        #region mouse/touch input
        if (Input.GetMouseButtonDown(0))
        {
            if (currGameState == eCurrentGameState.RandomizeAttackType)
            {
                stopSpinRouletteAtk = true;

                for (int i = 0; i < p1RouletteAtkBox.Length; i++)
                {
                    //boxes[i].transform.localPosition -= new Vector3(0, yOffset, 0);
                    p1RouletteAtkBox[i].transform.localPosition = p1RouletteAtkBoxStartPos[i];
                }

                p1CurrAtkType = getRouletteValue(p1RouletteAtkBox);
                Debug.Log("currAtkType:"+p1CurrAtkType);

                isWaiting = true;
            }
            else if (currGameState == eCurrentGameState.RandomizePowerType)
            {
                stopSpinRoulettePower = true;

                for (int i = 0; i < p1RoulettePowerBox.Length; i++)
                {
                    //boxes[i].transform.localPosition -= new Vector3(0, yOffset, 0);
                    p1RoulettePowerBox[i].transform.localPosition = p1RoulettePowerBoxStartPos[i];
                }

                p1CurrPower = getRouletteValue(p1RoulettePowerBox);
                Debug.Log("currPower:" + p1CurrPower);

                isWaiting = true;
            }
        }
        #endregion

        //start random atk/power
        if (!isWaiting)
        {
            //p1
            if (currGameState == eCurrentGameState.RandomizeAttackType)
            {
                Debug.Log("random atk");
                //RandomizeAttackPower(attackTypeList, p1AttackType, p1CurrAttackTypeIdx);
                //p1CurrAttackTypeIdx = rollIdx(attackTypeList.Length-1);
                //p1AttackType.text = attackTypeList[p1CurrAttackTypeIdx];
                spinRoulette(p1RouletteAtkBox);
            }
            else if (currGameState == eCurrentGameState.RandomizePowerType)
            {
                Debug.Log("random pow");
                //p1CurrPowerIdx = rollIdx(powerList.Length-1);
                //p1Power.text = powerList[p1CurrPowerIdx];
                spinRoulette(p1RoulettePowerBox);
            }
        } else if (isWaiting){
            //p2
            if (currGameState == eCurrentGameState.RandomizeAttackType)
            {
                //p2CurrAttackTypeIdx = rollIdx(attackTypeList.Length-1);
                //p2AttackType.text = attackTypeList[p1CurrAttackTypeIdx];
                spinRoulette(p2RouletteAtkBox);
            }
            else if (currGameState == eCurrentGameState.RandomizePowerType)
            {
                //p2CurrPowerIdx = rollIdx(powerList.Length-1);
                //p2Power.text = powerList[p1CurrAttackTypeIdx];
                spinRoulette(p2RoulettePowerBox);
            }
        }

        //wait random p2
        if (isWaiting) {
            waitTimer += Time.deltaTime;

            if (currGameState == eCurrentGameState.RandomizeAttackType)
            {
                stopSpinRouletteAtk = false;
            }
            else if (currGameState == eCurrentGameState.RandomizePowerType) {
                stopSpinRoulettePower = false;
            }
        }

        if (waitTimer > 1) {
            waitTimer = 0;
            isWaiting = false;

            if (currGameState == eCurrentGameState.RandomizeAttackType)
            {
                currGameState = eCurrentGameState.RandomizePowerType;

                //show enemy's attack type then switch to randomize power
                //p2CurrAttackTypeIdx = Random.Range(0, (attackTypeList.Length - 1));
                //p2AttackType.text = attackTypeList[p2CurrAttackTypeIdx];
                //Debug.Log("p2 attack type:" + attackTypeList[p2CurrAttackTypeIdx]);
                stopSpinRouletteAtk = true;

                for (int i = 0; i < p2RouletteAtkBox.Length; i++)
                {
                    //boxes[i].transform.localPosition -= new Vector3(0, yOffset, 0);
                    p2RouletteAtkBox[i].transform.localPosition = p2RouletteAtkBoxStartPos[i];
                }

                p2CurrAtkType = getRouletteValue(p2RouletteAtkBox);
                Debug.Log("currAtkType:" + p2CurrAtkType);

            }
            else if(currGameState == eCurrentGameState.RandomizePowerType){
                currGameState = eCurrentGameState.CompareDamage;

                //show enemy's power
                //p2CurrPowerIdx = Random.Range(0, (powerList.Length - 1));
                //p2Power.text = powerList[p2CurrPowerIdx];
                //Debug.Log("p2 power:" + powerList[p2CurrPowerIdx]);

                stopSpinRoulettePower = true;

                for (int i = 0; i < p2RoulettePowerBox.Length; i++)
                {
                    //boxes[i].transform.localPosition -= new Vector3(0, yOffset, 0);
                    p2RoulettePowerBox[i].transform.localPosition = p2RoulettePowerBoxStartPos[i];
                }

                p2CurrPower = getRouletteValue(p2RoulettePowerBox);
                Debug.Log("currPower:" + p2CurrPower);
            }
        }

        int p1Pow = int.Parse(p1CurrPower);
        int p2Pow = int.Parse(p2CurrPower);

        if (currGameState == eCurrentGameState.CompareDamage) {
            
            if (p1Pow == p2Pow)
            {
                drawMultiplier++;
                currGameState = eCurrentGameState.RandomizeAttackType;
                Debug.Log("drawMultiplier:" + drawMultiplier);
            }
            else {
                //attackIndex = Q = 0,T=1,S=2
                if (p1Pow > p2Pow)
                {
                    currDmg = DamageCalculator.CalculateDamage(p1Char, getAttackIndex(p1CurrAtkType), p2Char, drawMultiplier);
                }
                else {
                    currDmg = DamageCalculator.CalculateDamage(p2Char, getAttackIndex(p2CurrAtkType), p1Char, drawMultiplier);
                }
                Debug.Log("currDmg:" + currDmg);
                currGameState = eCurrentGameState.ApplyDamage;
            }
        }

        if (currGameState == eCurrentGameState.ApplyDamage) {
            if (p1Pow > p2Pow)
            {
                p2Char.Life -= currDmg;
                p2HPBar.fillAmount = p2Char.Life / p2Char.MaxLife;

                if (p2Char.Life <= 0) {
                    p1RoundCount++;
                }
            }
            else {
                p1Char.Life -= currDmg;
                p1HPBar.fillAmount = p1Char.Life / p1Char.MaxLife;

                if (p1Char.Life <= 0) {
                    p1RoundCount++;
                }
            }

            currGameState = eCurrentGameState.EndTurn;
        }

        if (currGameState == eCurrentGameState.EndTurn) {
            if (p1RoundCount >= 2)
            {
                //p1 wins
            }
            else if (p2RoundCount >= 2)
            {
                //p2 wins
            }
            else {
                //new round
                currGameState = eCurrentGameState.RandomizeAttackType;
            }
        }
	}

    //end of Update//

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

    void spinRoulette(GameObject[] currRoulette) {
        if (currGameState == eCurrentGameState.RandomizeAttackType) {
            stopSpinRouletteAtk = false;
        }
        else if(currGameState == eCurrentGameState.RandomizePowerType)
        {
            stopSpinRoulettePower = false;
        }

        if (currRoulette[currRoulette.Length - 2].transform.localPosition.y < -360)
        {

            //temp = boxes[3];
            //boxes[3] = boxes[2];
            //boxes[2] = boxes[1];
            //boxes[1] = boxes[0];
            //boxes[0] = temp;

            boxTemp = currRoulette[currRoulette.Length - 1];
            for (int i = (currRoulette.Length - 1); i > 0; i--)
            {
                currRoulette[i] = currRoulette[i - 1];
            }
            currRoulette[0] = boxTemp;

            currRoulette[0].transform.localPosition = new Vector3(0, 0, 0);

            if (currGameState == eCurrentGameState.RandomizeAttackType)
            {
                currRoulette[0].transform.localPosition = new Vector3(0, 0, 0);
            }
            else if (currGameState == eCurrentGameState.RandomizePowerType) {
                currRoulette[0].transform.localPosition = new Vector3(0, 180, 0);
            }

        }

        if (!stopSpinRouletteAtk || !stopSpinRoulettePower)
        {
            for (int i = 0; i < currRoulette.Length; i++)
            {
                currRoulette[i].transform.Translate(Vector3.down * 70, Space.Self);
                //rouletteAttackParent.transform.Translate(Vector3.down * 40, Space.Self);
            }
        }
    }

    string getRouletteValue(GameObject[] currBox) {
        return currBox[currBox.Length - 2].GetComponent<Roulette>().value;
    }

    int getAttackIndex(string currType) {
        if (currType == "Q")
        {
            return 0;
        }
        else if (currType == "T")
        {
            return 1;
        }
        else 
        {
            return 2;
        }

    }
}
