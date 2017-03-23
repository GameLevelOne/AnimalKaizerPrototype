using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpecialMove_", menuName = "Cards/Special Move", order = 1)]
public class SpecialMoveSO : ScriptableObject {
    public string specialMoveName = "NewSecialMove";
    public CharacterType specialMoveType = 0;
    public SkillData[] specialMoveEffect;
	
}
