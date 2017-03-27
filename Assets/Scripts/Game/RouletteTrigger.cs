using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteTrigger : MonoBehaviour {
    public string p1CurrAtkBoxValue;
    public string p2CurrAtkboxValue;
    public string p1CurrPowerBoxValue;
    public string p2CurrPowerBoxValue;

    private string rouletteP1Attack = "roulette_P1_Attack";
    private string rouletteP2Attack = "roulette_P2_Attack";
    private string rouletteP1Power = "roulette_P1_Power";
    private string rouletteP2Power = "roulette_P2_Power";

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == rouletteP1Attack) {
            p1CurrAtkBoxValue = col.GetComponent<Roulette>().value;
        }
        if (col.tag == rouletteP1Power){
            p1CurrPowerBoxValue = col.GetComponent<Roulette>().value;
        }
        if (col.tag == rouletteP2Attack){
            p2CurrAtkboxValue = col.GetComponent<Roulette>().value;
        }
        if (col.tag == rouletteP2Power){
            p2CurrPowerBoxValue = col.GetComponent<Roulette>().value;
        }
    }

}
