using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DamageCalculator {

	public static int CalculateDamage(Character attacker, int attackIndex, Character defender, float drawMultiplier, bool winStruggle = false)
    {
		int power = attackIndex < 3 ? attacker.charData.charPower : attacker.specialMove.specialMoveSO.specialMovePower;
		if (winStruggle) {
			power *= 2;
		}
		int strength = (int)(drawMultiplier * power);
        int damage = defender.support.Def - strength;
        return damage < 0 ? 0 : damage;
    }

}
