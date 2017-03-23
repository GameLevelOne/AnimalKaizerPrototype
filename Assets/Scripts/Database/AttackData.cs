using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    Guts,
    Power,
    Tech
}

public class AttackData {
    public string attackName;
    public AttackType attackType;
    public Animation attackAnimation;
    public float attackMultiplier;
}
