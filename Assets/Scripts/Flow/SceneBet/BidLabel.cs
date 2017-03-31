using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BidLabel : MonoBehaviour {

	public Text bidText;
	int curBid;

	void OnEnable()
	{
		curBid = 500;
		bidText.text = "BID: "+curBid+"\n\nPAYOUT:";
	}

	public void addBid (int newBid) {
		curBid += newBid;
		bidText.text = "BID: "+curBid+"\n\nPAYOUT:";
	}
	
}
