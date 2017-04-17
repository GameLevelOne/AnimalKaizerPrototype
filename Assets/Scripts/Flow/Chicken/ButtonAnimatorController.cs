using System.Collections;
using UnityEngine;

public class ButtonAnimatorController : MonoBehaviour {
	IEnumerator Start(){
		yield return new WaitUntil(()=>GetComponent<Animator>().isInitialized);
	}
}
