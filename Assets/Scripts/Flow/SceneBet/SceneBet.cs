using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBet : MonoBehaviour {

	public Payout payout;

	void Start () {
		payout.InitPayout ();		
	}
	
}
