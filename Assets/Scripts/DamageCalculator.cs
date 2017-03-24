using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DamageCalculator {

    public static int CalculateDamage(Character attacker, int attackIndex, Character defender, float drawMultiplier)
    {
        int strength = (int)(drawMultiplier * attacker.charData.charPower);
        int damage = defender.support.Def - strength;
        return damage < 0 ? 0 : damage;
    }
}
