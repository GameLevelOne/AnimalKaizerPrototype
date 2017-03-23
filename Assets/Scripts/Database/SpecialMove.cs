using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMove : MonoBehaviour {

    public SpecialMoveSO specialMoveSO;

    public SpecialMove(SpecialMoveSO spmSO)
    {
        if (spmSO != null)
        {
            specialMoveSO = spmSO;
        }
    }

}
