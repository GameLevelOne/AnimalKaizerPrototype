using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteTrigger : MonoBehaviour {
    public GameObject currObj;

    private string rouletteAttack = "roulette_Attack";
    private string roulettePower = "roulette_Power";

    private float currY=0f;
    

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == rouletteAttack)
        {
            Debug.Log(col.gameObject.GetComponent<Roulette>().value);
            currY = col.transform.position.y;
            currObj = col.gameObject;
        }
        else if(col.tag == roulettePower){

        }
    }

}
