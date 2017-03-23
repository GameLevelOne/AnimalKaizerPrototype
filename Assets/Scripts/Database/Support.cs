using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Support : MonoBehaviour {

    public SupportSO supportSO;

    public void InitSupport(SupportSO supSO = null)
    {
        if (supSO != null)
        {
            supportSO = supSO;
        }
    }

    public int Def
    {
        get
        {
            return supportSO.supportDefense;
        }
    }

}
