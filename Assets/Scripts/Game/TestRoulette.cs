using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRoulette : MonoBehaviour {
    public RouletteTrigger rouletteTrigger;

    public GameObject[] boxes = new GameObject[3];
    public GameObject rouletteAttackParent;

    private GameObject temp;
    private bool stopSpin = false;
    private float yOffset = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {

            yOffset = -180 - rouletteTrigger.currObj.transform.position.y;
            Debug.Log("yOffset:" + yOffset);
            rouletteTrigger.currObj.transform.localPosition = new Vector3(0, -180, 0);

            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i].transform.localPosition -= new Vector3(0, yOffset, 0);
            }

            Debug.Log("click");
            stopSpin = true;
        }

        if (boxes[boxes.Length-2].transform.localPosition.y < -360)
        {

            //temp = boxes[3];
            //boxes[3] = boxes[2];
            //boxes[2] = boxes[1];
            //boxes[1] = boxes[0];
            //boxes[0] = temp;

            temp = boxes[boxes.Length-1];
            for (int i = (boxes.Length - 1); i > 0; i--) {
                boxes[i] = boxes[i - 1];
            }
            boxes[0] = temp;

            boxes[0].transform.localPosition= new Vector3(0, 0, 0);
        }

        if (!stopSpin)
        {
            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i].transform.Translate(Vector3.down * 40, Space.Self);
                //rouletteAttackParent.transform.Translate(Vector3.down * 40, Space.Self);
            }
        }
    }
}
