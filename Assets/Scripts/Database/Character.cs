using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character{

    public CharacterSO charData;
    public Support support;
    public SpecialMove specialMove;
    int curLife;

    public Character(CharacterSO charSO)
    {
        if (charSO!=null)
        {
            charData = charSO;
            curLife = charData.charHealth;
        }

    }
    public void Combine(Support supportObject)
    {
        support = supportObject;
    }
    public void Combine(SpecialMove specialMoveObject)
    {
        specialMove = specialMoveObject;
    }

    public int MaxLife 
    {
        get
        {
            return charData.charHealth;
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
