using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    QUICK,
    TECHNICAL,
    STRONG
}

[System.Serializable]
public class AttackData {
    public string attackName;
    public AttackType attackType;
    public Animation attackAnimation;
    public float attackMultiplier;
}
