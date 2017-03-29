using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMove{

    public SpecialMoveSO specialMoveSO;

    public SpecialMove(SpecialMoveSO spmSO)
    {
        if (spmSO != null)
        {
            specialMoveSO = spmSO;
        }
    }

}
