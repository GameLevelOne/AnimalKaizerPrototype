using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComparePowerSFX : MonoBehaviour {

    public void playCompareSFX() {
        AudioManager.Instance.PlaySFX(eSFX.POWER_COMPARISON);
    }
}
