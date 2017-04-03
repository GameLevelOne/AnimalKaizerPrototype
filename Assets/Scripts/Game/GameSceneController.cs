using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum eCurrentGameState {
    Countdown = 0,
    RandomizeAttackType,
    RandomizePowerType,
    CompareDamage,
    ComparePowerAnimation,
    Struggle,
    ApplyDamage,
	MoveNameAnim,
    AttackAnim,
    EndTurn,
    AddRound,
    EndRound,
    EndGame,
    Transition
}

public class GameSceneController : MonoBehaviour {
	public Animator mainCamAnim;

    public RouletteTrigger rouletteTrigger;

    public GameObject panelCountdown,panelEndBattle, panelStruggle;
    public GameObject panelComparePower;
    public GameObject p1PlayerParent, p1SupportParent, p2PlayerParent, p2SupportParent, 
        p1AtkRoulette, p1PowerRoulette, p2AtkRoulette, p2PowerRoulette;

    public Text p1NameDisplay, p2NameDisplay;

    public Image textRound;
    public Sprite[] roundSprite;
    public Image p1WinCount;
    public Image p2WinCount;
    public Sprite[] countSprite;
    public Image timer;
    public Sprite fightSprite;
    public Image textEnd;
    public Sprite youWinSprite;
    public Sprite youLoseSprite;
    public Sprite gameOverSprite;
    public Image p1PowerLabel;
    public Image p2PowerLabel;
    public Sprite[] powerSprite;
    public Text multiplierText;
	public Text moveNameText;
	public Text damageText;
    public Sprite[] struggleButtonSprite;
    public Image buttonStruggle;

    public Image p1HPBar,p2HPBar;

    public Animator charaAnim;

    public GameObject[] charactersObj = new GameObject[6];
    public GameObject[] p1RouletteAtkBox = new GameObject[3];
    public GameObject[] p2RouletteAtkBox = new GameObject[3];
    public GameObject[] p1RoulettePowerBox = new GameObject[4];
    public GameObject[] p2RoulettePowerBox = new GameObject[4];

    private Vector3[] p1RouletteAtkBoxStartPos = new Vector3[3];
    private Vector3[] p2RouletteAtkBoxStartPos = new Vector3[3];
    private Vector3[] p1RoulettePowerBoxStartPos = new Vector3[4];
    private Vector3[] p2RoulettePowerBoxStartPos = new Vector3[4];

    private Character p1Char, p2Char;

    private GameObject boxTemp;

    private string[] attackTypeList = new string[3] { "Q", "T", "S" };
    private string[] powerList = new string[4] { "20", "30", "40", "50" };

    private string p1CurrAtkType;
    private string p2CurrAtkType;
    private string p1CurrPower;
    private string p2CurrPower;
    private string charaAnim_TriggerAttack = "attack";
    private string charaAnim_TriggerAttacked = "attacked";

    private bool isWaiting = false;
    private bool stopSpinRouletteAtk = true;
    private bool stopSpinRoulettePower = true;
    private bool enterCountdown = false;
    private bool p1Win = false;
    private bool waitForAttackAnim = false;
    private bool focusMove = false;
    private bool enterStruggle = false;
    private bool winStruggle = false;

    private float waitTimer = 0f;
    private float animTimer = 0f;
    private float struggleTimer = 0f;

    private int p1CurrAttackTypeIdx = 0;
    private int p2CurrAttackTypeIdx = 0;
    private int p1CurrPowerIdx = 0;
    private int p2CurrPowerIdx = 0;
    private int currDmg = 0;
	private float curLife = 0f;
	private float targetLife = 0f;
	private float lifeDelta = 0f;
    private int drawMultiplier = 1;
    private int p1RoundCount = 0;
    private int p2RoundCount = 0;
    private int currRound = 1;
    private int p1Pow = 0;
    private int p2Pow = 0;
    private int tapCount = 0;

    private eCurrentGameState currGameState = eCurrentGameState.Countdown;

    public Fader fader;

	// Use this for initialization
	void Start () {
        fader.FadeIn();
        for (int i = 0; i < 3; i++) {
            p1RouletteAtkBoxStartPos[i] = p1RouletteAtkBox[i].transform.localPosition;
            p2RouletteAtkBoxStartPos[i] = p2RouletteAtkBox[i].transform.localPosition;
        }

        for (int i = 0; i < 4; i++) {
            p1RoulettePowerBoxStartPos[i] = p1RoulettePowerBox[i].transform.localPosition;
            p2RoulettePowerBoxStartPos[i] = p2RoulettePowerBox[i].transform.localPosition;
        }

        p1Char = PlayerDataController.Instance.playerChar;
        p2Char = PlayerDataController.Instance.enemyChar;

        p1Char.Life = p1Char.MaxLife;
        p2Char.Life = p2Char.MaxLife;

//        Debug.Log("p1 HP: " + p1Char.Life);
//        Debug.Log("p2 HP: " + p2Char.Life);

        stageSetup(p1Char.charData.charName, p1Char.support.supportSO.supportName, 
            p2Char.charData.charName, p2Char.support.supportSO.supportName);
        
	}
	
	// Update is called once per frame
	void Update () {

        if (currGameState == eCurrentGameState.Countdown && !enterCountdown) {
            enterCountdown = true;
            multiplierText.text = "";
            p1AtkRoulette.SetActive(false);
            p1PowerRoulette.SetActive(false);
            p2AtkRoulette.SetActive(false);
            p2PowerRoulette.SetActive(false);
            StartCoroutine(StartCountdown());
        }


        //start random atk/power
        if (!isWaiting)
        {
            //p1
            if (currGameState == eCurrentGameState.RandomizeAttackType)
            {
                //RandomizeAttackPower(attackTypeList, p1AttackType, p1CurrAttackTypeIdx);
                //p1CurrAttackTypeIdx = rollIdx(attackTypeList.Length-1);
                //p1AttackType.text = attackTypeList[p1CurrAttackTypeIdx];
                p1AtkRoulette.SetActive(true);
                spinRoulette(p1RouletteAtkBox);
            }
            else if (currGameState == eCurrentGameState.RandomizePowerType)
            {
                //p1CurrPowerIdx = rollIdx(powerList.Length-1);
                //p1Power.text = powerList[p1CurrPowerIdx];
                p1PowerRoulette.SetActive(true);
                spinRoulette(p1RoulettePowerBox);
            }
        } else if (isWaiting){
            //p2
            if (currGameState == eCurrentGameState.RandomizeAttackType)
            {
                //p2CurrAttackTypeIdx = rollIdx(attackTypeList.Length-1);
                //p2AttackType.text = attackTypeList[p1CurrAttackTypeIdx];
                p2AtkRoulette.SetActive(true);
                spinRoulette(p2RouletteAtkBox);
            }
            else if (currGameState == eCurrentGameState.RandomizePowerType)
            {
                //p2CurrPowerIdx = rollIdx(powerList.Length-1);
                //p2Power.text = powerList[p1CurrAttackTypeIdx];
                p2PowerRoulette.SetActive(true);
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
//                Debug.Log("p2 currAtkType:" + p2CurrAtkType);
				isWaiting = true;
                currGameState = eCurrentGameState.RandomizePowerType;

            }
            else if(currGameState == eCurrentGameState.RandomizePowerType){
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
//                Debug.Log("p2 currPower:" + p2CurrPower);
                currGameState = eCurrentGameState.CompareDamage;
            }
        }

		#region mouse/touch input
		if (Input.GetMouseButtonDown(0))
		{
			if ((currGameState == eCurrentGameState.RandomizeAttackType) && (!isWaiting))
			{
				stopSpinRouletteAtk = true;

				for (int i = 0; i < p1RouletteAtkBox.Length; i++)
				{
					//boxes[i].transform.localPosition -= new Vector3(0, yOffset, 0);
					p1RouletteAtkBox[i].transform.localPosition = p1RouletteAtkBoxStartPos[i];
				}

				p1CurrAtkType = getRouletteValue(p1RouletteAtkBox);
//				Debug.Log("p1 currAtkType:"+p1CurrAtkType);
				currGameState = eCurrentGameState.RandomizePowerType;
//				isWaiting = true;
			}
			else if ((currGameState == eCurrentGameState.RandomizePowerType) && (!isWaiting))
			{
				stopSpinRoulettePower = true;

				for (int i = 0; i < p1RoulettePowerBox.Length; i++)
				{
					//boxes[i].transform.localPosition -= new Vector3(0, yOffset, 0);
					p1RoulettePowerBox[i].transform.localPosition = p1RoulettePowerBoxStartPos[i];
				}

				p1CurrPower = getRouletteValue(p1RoulettePowerBox);
//				Debug.Log("p2 currPower:" + p1CurrPower);

				mainCamAnim.SetTrigger("EnemySelection");
				isWaiting = true;
				currGameState = eCurrentGameState.RandomizeAttackType;
			}
		}
		#endregion

        if (currGameState == eCurrentGameState.CompareDamage) {
//            Debug.Log("compare power");
            p1Pow = int.Parse(p1CurrPower);
            p2Pow = int.Parse(p2CurrPower);
            int p1AtkInt = getAttackIndex(p1CurrAtkType);
            int p2AtkInt = getAttackIndex(p2CurrAtkType);
            bool p1Enhanced = false;
            bool p2Enhanced = false;

            if (p1AtkInt > p2AtkInt)
            {
                //p1Atk
                if (p2AtkInt == (int)p2Char.support.supportSO.supportEnhance)
                {
                    p2Enhanced = true;
                }

                if (p1AtkInt == (int)p1Char.support.supportSO.supportEnhance)
                {
                    //p1 focusatk
                    if (Random.value >= 0.5)
                    {
//                        Debug.Log("focus!");
                        focusMove = true;
                    }
                    else
                    {
                        focusMove = false;
                    }
                }

            }
            else {
                //p2Atk
                if (p1AtkInt == (int)p1Char.support.supportSO.supportEnhance)
                {
                    p1Enhanced = true;
                }

                if (p2AtkInt == (int)p2Char.support.supportSO.supportEnhance)
                {
                    //p2 focusatk
                    if (Random.value >= 0.5)
                    {
//                        Debug.Log("focus!");
                        focusMove = true;
                    }
                    else
                    {
                        focusMove = false;
                    }
                }
            }

            //test
            //focusMove = true;
            //p2Enhanced = true;

            if ((focusMove && p2Enhanced) || (focusMove && p1Enhanced)) {
                enterStruggle = true;
                currGameState = eCurrentGameState.Struggle;
            }

            if (p1Pow == p2Pow)
            {
                if (drawMultiplier < 10)
                    drawMultiplier++;
                else
                    drawMultiplier = 10;
                StartCoroutine(ComparePowerAnim("Draw"));
                currGameState = eCurrentGameState.ComparePowerAnimation;
                enterStruggle = false;
//                Debug.Log("drawMultiplier:" + drawMultiplier);
            }
            else
            {
                if (!enterStruggle)
                {
                    //attackIndex = Q = 0,T=1,S=2
                    if (p1Pow > p2Pow)
                    {
                        //p1 winStruggle
//                        Debug.Log("p1Power: " + p1Char.charData.charPower);
                        currDmg = DamageCalculator.CalculateDamage(p1Char, getAttackIndex(p1CurrAtkType), p2Char, drawMultiplier, false);
                        //currDmg = 5000;
                        StartCoroutine(ComparePowerAnim("P1Win"));
                    }
                    else
                    {
                        //p2 winStruggle
//                        Debug.Log("p2Power: " + p2Char.charData.charPower);
                        currDmg = DamageCalculator.CalculateDamage(p2Char, getAttackIndex(p2CurrAtkType), p1Char, drawMultiplier, false);
                        //currDmg = 5000;
                        StartCoroutine(ComparePowerAnim("P2Win"));
                    }
//                    Debug.Log("currDmg:" + currDmg);
                    resetBattleBool();
                    currGameState = eCurrentGameState.ComparePowerAnimation;
                }
                else {
                    currGameState = eCurrentGameState.Struggle;
                }
            }
        }

        if (currGameState == eCurrentGameState.Struggle)
        {
            bool waitStruggle = true;
//            Debug.Log("struggle");
            panelStruggle.SetActive(true);

			if (struggleTimer == 0f)
				mainCamAnim.SetTrigger ("Struggle");

            struggleTimer += Time.deltaTime;

            if (Input.GetMouseButtonDown(0))
            {
                buttonStruggle.sprite = struggleButtonSprite[0];
                Debug.Log("tapCount: " + tapCount);
                if (tapCount < 10)
                {
                    tapCount++;
                }
            }

            if (Input.GetMouseButtonUp(0)) {
                buttonStruggle.sprite = struggleButtonSprite[1];
            }

            if (tapCount >= 10) {
                winStruggle = true;
            }

            if (struggleTimer >= 4f) {
//                Debug.Log("Time's up");
//                Debug.Log("Tap Count: " + tapCount);
                if (tapCount >= 10)
                {
                    winStruggle = true;
                }
                else {
                    winStruggle = false;
                }
                struggleTimer = 0;
                waitStruggle = false;
            }

            if (!waitStruggle)
            {
                if (winStruggle)
                {
                    struggleTimer = 0;
//                    Debug.Log("win struggle");
                    //attackIndex = Q = 0,T=1,S=2
                    if (p1Pow > p2Pow)
                    {
//                        Debug.Log("p1Power: " + p1Char.charData.charPower);
                        currDmg = DamageCalculator.CalculateDamage(p1Char, getAttackIndex(p1CurrAtkType), p2Char, drawMultiplier, true);
                        StartCoroutine(ComparePowerAnim("P1Win"));
                        //currDmg = 5000;
                    }
                    else
                    {
//                        Debug.Log("p2Power: " + p2Char.charData.charPower);
                        currDmg = DamageCalculator.CalculateDamage(p2Char, getAttackIndex(p2CurrAtkType), p1Char, drawMultiplier, false);
                        StartCoroutine(ComparePowerAnim("P2Win"));
                        //currDmg = 5000;
                    }
//                    Debug.Log("currDmg:" + currDmg);
                    resetBattleBool();
                    panelStruggle.SetActive(false);
                    currGameState = eCurrentGameState.ComparePowerAnimation;
                }
                else
                {
//                    Debug.Log("lost struggle");

                    if (p1Pow > p2Pow)
                    {
//                        Debug.Log("p1Power: " + p1Char.charData.charPower);
                        currDmg = DamageCalculator.CalculateDamage(p1Char, getAttackIndex(p1CurrAtkType), p2Char, drawMultiplier, false);
                        StartCoroutine(ComparePowerAnim("P1Win"));
                        //currDmg = 5000;
                    }
                    else
                    {
//                        Debug.Log("p2Power: " + p2Char.charData.charPower);
                        currDmg = DamageCalculator.CalculateDamage(p2Char, getAttackIndex(p2CurrAtkType), p1Char, drawMultiplier, false);
                        StartCoroutine(ComparePowerAnim("P2Win"));
                        //currDmg = 5000;
                    }
//                    Debug.Log("currDmg:" + currDmg);
                    resetBattleBool();
                    panelStruggle.SetActive(false);
                    currGameState = eCurrentGameState.ComparePowerAnimation;
                }
            }
        }

		if (currGameState == eCurrentGameState.MoveNameAnim)
		{
			if (animTimer == 0f) {
				moveNameText.gameObject.SetActive (true);
				if (p1Pow>p2Pow)
					mainCamAnim.SetTrigger ("PlayerMoveName");
				else
					mainCamAnim.SetTrigger ("EnemyMoveName");
			}

			animTimer += Time.deltaTime;

			if (animTimer > 2f)
			{
				animTimer = 0f;
				currGameState = eCurrentGameState.AttackAnim;
				moveNameText.gameObject.SetActive (false);
			}
		}

		if (currGameState == eCurrentGameState.AttackAnim)
		{
			if (animTimer == 0f) {
				if (p1Pow > p2Pow) {
					charaAnim.SetTrigger(charaAnim_TriggerAttack);
					mainCamAnim.SetTrigger ("PlayerAttack");
				} else {
					charaAnim.SetTrigger(charaAnim_TriggerAttacked);
					mainCamAnim.SetTrigger ("EnemyAttack");
				}
			}

			if (waitForAttackAnim)
			{
				animTimer += Time.deltaTime;
			}

			if (animTimer > 0.5f)
			{
				animTimer = 0f;
				waitForAttackAnim = false;
				currGameState = eCurrentGameState.ApplyDamage;
			}
		}

        if (currGameState == eCurrentGameState.ApplyDamage) {
//            Debug.Log("apply dmg");


			if (animTimer == 0f) {
				if (p1Pow > p2Pow) {
					damageText.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (300,-200);
					curLife = p2Char.Life;
					if ((p2Char.Life - currDmg) <= 0) {
						p2Char.Life = 0;
					} else {
						p2Char.Life -= currDmg;
					}
					targetLife = p2Char.Life;
				} else {
					damageText.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-300,-200);
					curLife = p1Char.Life;
					if ((p1Char.Life - currDmg) <= 0) {
						p1Char.Life = 0;
					} else {
						p1Char.Life -= currDmg;
					}
					targetLife = p1Char.Life;
				}
				lifeDelta = (curLife-targetLife) * 1.5f;
				damageText.text = currDmg.ToString ("N0");
				damageText.gameObject.SetActive (true);
			}
			if (animTimer < 2f) {
				animTimer += Time.deltaTime;

				if (curLife > targetLife) {
					curLife -= (lifeDelta * Time.deltaTime);
					if (curLife < targetLife)
						curLife = targetLife;
				} 

				if (p1Pow > p2Pow) {
					p2HPBar.fillAmount = (float) curLife / p2Char.MaxLife;
				} else {
					p1HPBar.fillAmount = (float) curLife / p1Char.MaxLife;
				}

			} else {
				animTimer = 0f;
				damageText.gameObject.SetActive (false);

				if (p1Pow > p2Pow)
				{
					if (p2Char.Life <= 0) {
						p1RoundCount++;
//						Debug.Log("p1RoundCount: " + p1RoundCount); //start new round
						p1Win = true;
					}
				}
				else
				{
					if (p1Char.Life <= 0) {
						p2RoundCount++;
//						Debug.Log("p2RoundCount: " + p2RoundCount); //start new round
						p1Win = false;
					}
				}
				currGameState = eCurrentGameState.EndTurn;
			}

        }
			
        if (currGameState == eCurrentGameState.EndTurn) {
            drawMultiplier = 1;
            multiplierText.text = "";
//            Debug.Log("end round");

            if (p1RoundCount >= 2)
            {
                //p1 wins
//                Debug.Log("p1 wins");
                p1Win = true;
                currGameState = eCurrentGameState.EndGame;
            }
            else if (p2RoundCount >= 2)
            {
                //p2 wins
//                Debug.Log("p2 wins");
                p1Win = false;
                currGameState = eCurrentGameState.EndGame;
            }
            else {
                if (p1Char.Life <= 0 || p2Char.Life <= 0)
                {
                    //new round
//                    Debug.Log("new round");
                    if (p1Char.Life <= 0) {
                        p1Win = false;
                    }
                    else
                    {
                        p1Win = true;
                    }
                    currGameState = eCurrentGameState.AddRound;
                }
                else {
                    //new turn (in the same round)
//                    Debug.Log("new turn");
                    currGameState = eCurrentGameState.RandomizeAttackType;
					mainCamAnim.SetTrigger ("PlayerSelection");
                }
            }
        }

        if (currGameState == eCurrentGameState.AddRound) {
            currRound++;
            currGameState = eCurrentGameState.EndRound;
        }

        if (currGameState == eCurrentGameState.EndRound) {
            enterCountdown = false;
            StartCoroutine(EndBattle(false,p1Win));
            currGameState = eCurrentGameState.Transition;
        } else if (currGameState == eCurrentGameState.EndGame) {
            //battle result
            StartCoroutine(EndBattle(true, p1Win));
            currGameState = eCurrentGameState.Transition;
        }
	}

    //end of Update//

    IEnumerator ComparePowerAnim(string animTrigger)
    {
        Animator anim = panelComparePower.GetComponent<Animator>();
        p1PowerLabel.sprite = powerSprite[(p1Pow / 10) - 2];
        p2PowerLabel.sprite = powerSprite[(p2Pow / 10) - 2];
		mainCamAnim.SetTrigger ("CompareResults");
        anim.SetTrigger(animTrigger);
        if (animTrigger=="Draw")
        {
            StartCoroutine(MultiplierChange());
        }
        yield return new WaitForSeconds(2);
        
        p1AtkRoulette.SetActive(false);
        p1PowerRoulette.SetActive(false);
        p2AtkRoulette.SetActive(false);
        p2PowerRoulette.SetActive(false);

        if (p1Pow > p2Pow)
        {
			animTimer = 0f;
			waitForAttackAnim = true;
			currGameState = eCurrentGameState.MoveNameAnim;
			moveNameText.text = p1Char.charData.charAttackData [getAttackIndex (p1CurrAtkType)].attackName.ToUpper();
        }
        else if (p1Pow < p2Pow)
        {
			animTimer = 0f;
			waitForAttackAnim = true;
			currGameState = eCurrentGameState.MoveNameAnim;
			moveNameText.text = p2Char.charData.charAttackData [getAttackIndex (p2CurrAtkType)].attackName.ToUpper();
        }
        else
        {
            currGameState = eCurrentGameState.RandomizeAttackType;
			mainCamAnim.SetTrigger ("PlayerSelection");
        }
    }
    IEnumerator MultiplierChange()
    {
        Animator anim = multiplierText.GetComponent<Animator>();
        yield return new WaitForSeconds(1);
        multiplierText.text = "" + drawMultiplier + "X DMG";
        anim.SetTrigger("ScaleIn");
    }

    IEnumerator StartCountdown() {
        Animator timerAnim = timer.GetComponent<Animator>();
        timer.enabled = false;
        resetHP();
        panelCountdown.SetActive(true);
        yield return new WaitForSeconds(1);
        timer.enabled = true;
        timerAnim.SetTrigger("Round");
        timer.sprite = roundSprite[currRound-1];
        yield return new WaitForSeconds(2);
		mainCamAnim.SetTrigger ("CountDown");
        timerAnim.SetTrigger("Count");
        timer.sprite = countSprite[2];
        yield return new WaitForSeconds(1);
        timerAnim.SetTrigger("Count");
        timer.sprite = countSprite[1];
        yield return new WaitForSeconds(1);
        timerAnim.SetTrigger("Count");
        timer.sprite = countSprite[0];
        yield return new WaitForSeconds(1);
        timerAnim.SetTrigger("Fight");
        timer.sprite = fightSprite;
        yield return new WaitForSeconds(2);
        panelCountdown.SetActive(false);
        p1AtkRoulette.SetActive(true);
		mainCamAnim.SetTrigger ("PlayerSelection");
        currGameState = eCurrentGameState.RandomizeAttackType;
    }

    IEnumerator EndBattle(bool endGame,bool p1Win) {
        textEnd.enabled = false;
        panelEndBattle.SetActive(true);
        if (p1RoundCount > 0)
        {
            p1WinCount.sprite = countSprite[p1RoundCount - 1];
            p1WinCount.enabled = true;
        }
        else
        {
            p1WinCount.enabled = false;
        }
        if (p2RoundCount > 0)
        {
            p2WinCount.sprite = countSprite[p2RoundCount - 1];
            p2WinCount.enabled = true;
        }
        else
        {
            p2WinCount.enabled = false;
        }
        yield return new WaitForSeconds(1);

        textEnd.enabled = true;
        Animator textAnim = textEnd.GetComponent<Animator>();
        if (!textAnim.isInitialized)
            textAnim.Rebind();
        if (p1Win)
        {
            textEnd.sprite = youWinSprite;
			mainCamAnim.SetTrigger ("PlayerWin");
        }
        else {
            textEnd.sprite = youLoseSprite;
			mainCamAnim.SetTrigger ("EnemyWin");
        }
        textAnim.SetTrigger("RoundEnd");
        yield return new WaitForSeconds(2);

        if (endGame)
        {
            textEnd.sprite = gameOverSprite;
			mainCamAnim.SetTrigger ("GameOver");
            textAnim.SetTrigger("RoundGameOver");
            yield return new WaitForSeconds(2);
			if (p1Win)
				PlayerPrefs.SetInt ("PlayerWin",1);
            fader.FadeOut();
            fader.OnFadeOutFinished += FinishedFadeOut;            
        }
        else {
            panelEndBattle.SetActive(false);
            textRound.sprite = roundSprite[currRound-1];
            currGameState = eCurrentGameState.Countdown;
        }
    }
    void FinishedFadeOut()
    {
        fader.OnFadeOutFinished -= FinishedFadeOut;
        SceneManager.LoadScene("Scene ThankYou");
    }
    void stageSetup(string p1PlayerName,string p1SupportName,string p2PlayerName,string p2SupportName) {
        Vector3 tempPos = new Vector3(0, 0, 0);

        GameObject p1PlayerObj = GameObject.Instantiate(charactersObj[getCharCode(p1PlayerName)], tempPos, Quaternion.identity);
        GameObject p1SupportObj = GameObject.Instantiate(charactersObj[getCharCode(p1SupportName)], tempPos, Quaternion.identity);
        GameObject p2PlayerObj = GameObject.Instantiate(charactersObj[getCharCode(p2PlayerName)], tempPos, Quaternion.identity);
        GameObject p2SupportObj = GameObject.Instantiate(charactersObj[getCharCode(p2SupportName)], tempPos, Quaternion.identity);

        p1PlayerObj.transform.SetParent(p1PlayerParent.transform,false);
        p1SupportObj.transform.SetParent(p1SupportParent.transform,false);
        p2PlayerObj.transform.SetParent(p2PlayerParent.transform,false);
        p2SupportObj.transform.SetParent(p2SupportParent.transform,false);

		p1NameDisplay.text = p1PlayerName.ToUpper();
		p2NameDisplay.text = p2PlayerName.ToUpper();

        panelComparePower.SetActive(true);
    }

    void spinRoulette(GameObject[] currRoulette) {
        for (int i = 0; i < currRoulette.Length; i++) {
            currRoulette[i].SetActive(true);
        }

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
//                currRoulette[i].transform.Translate(Vector3.down * 500 * Time.deltaTime, Space.Self);
				currRoulette[i].transform.Translate(Vector3.down * 1500 * Time.deltaTime);
                //rouletteAttackParent.transform.Translate(Vector3.down * 40, Space.Self);
            }
        }
    }

    void resetHP() {
        p1Char.Life = p1Char.MaxLife;
        p2Char.Life = p2Char.MaxLife;
        p1HPBar.fillAmount = 1;
        p2HPBar.fillAmount = 1;
    }

    void resetBattleBool() {
        focusMove = false;
        enterStruggle = false;
        winStruggle = false;
    }

    string getRouletteValue(GameObject[] currBox) {
        for (int i = 0; i < currBox.Length; i++) {
            if (i != (currBox.Length - 2))
            {
                currBox[i].SetActive(false);
            }
        }

        return currBox[currBox.Length - 2].GetComponent<Roulette>().value;
    }

    int getAttackIndex(string currType) {
        int temp = -1;
        switch (currType) {
            case "Q": temp = (int) AttackType.QUICK; break;
            case "T": temp = (int) AttackType.TECHNICAL; break;
            case "S": temp = (int) AttackType.STRONG; break;
        }
        return temp;
    }

    int getCharCode(string name)
    {
        int temp = -1;
        switch (name)
        {
            case "Genderuwo": temp = 0; break;
            case "Kunti": temp = 1; break;
            case "Kolorijo": temp = 2; break;
            case "Pocong": temp = 3; break;
            case "Tuyul": temp = 4; break;
            case "Suster Ngesot": temp = 5; break;
        }
        return temp;
    }
}
