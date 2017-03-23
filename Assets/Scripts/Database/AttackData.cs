using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    QUICK,
    TECHNICAL,
    STRONG
}

public class AttackData {
    public string attackName;
    public AttackType attackType;
    public Animation attackAnimation;
    public float attackMultiplier;
}
