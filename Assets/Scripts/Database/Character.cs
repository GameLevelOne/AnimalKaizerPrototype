using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public CharacterSO characterSO;
    int curLife;

    public void InitCharacter(CharacterSO charSO=null)
    {
        if (charSO!=null)
        {
            characterSO = charSO;
            curLife = characterSO.charHealth;
        }
    }

    public int MaxLife 
    {
        get
        {
            return characterSO.charHealth;
        }
    }
    public int Life
    {
        get
        {
            return curLife;
        }
        set
        {
            curLife = value;
        }
    }
}
