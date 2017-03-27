using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DamageCalculator {

	public static int CalculateDamage(Character attacker, int attackIndex, Character defender, float drawMultiplier = 1f, bool winStruggle = false)
    {
		//Jika Attack adalah special moves, maka yang dipakai power dari Special move
		int power = attackIndex < 3 ? attacker.charData.charPower : attacker.specialMove.specialMoveSO.specialMovePower;

		//Jika attack sesuai focus
		if (attacker.charData.charAttackData [attackIndex].attackType == attacker.support.supportSO.supportEnhance) {
			power += attacker.support.supportSO.supportFocus;
		}

		//Jika menang struggle maka power kali 2
		if (winStruggle) {
			power *= 2;
		}

		//check multiplier dari draw
		int strength = (int)(drawMultiplier * power);

		//total damage
        int damage = defender.support.Def - strength;
        return damage < 0 ? 0 : damage;
    }

}
