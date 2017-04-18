using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType 
{
    DEF,
    ATK,
    SPD
}

[CreateAssetMenu(fileName= "Char_", menuName = "Cards/Character", order = 1)]
public class CharacterSO : ScriptableObject {

    public string charName = "NewChar";
    public Mesh charMesh = null;
    public CharacterType charType = 0;
    public int charPower = 1000;
    public int charHealth = 1000;
	public int charPrice = 0;
    public AttackData[] charAttackData;
    public SkillData[] charSkills;
}
