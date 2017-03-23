using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMove : MonoBehaviour {

    public SpecialMoveSO specialMoveSO;

    public void InitSpecialMove(SpecialMoveSO spmSO = null)
    {
        if (spmSO != null)
        {
            specialMoveSO = spmSO;
        }
    }

}
