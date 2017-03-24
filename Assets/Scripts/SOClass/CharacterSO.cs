﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType 
{
    Fire,
    Water,
    Earth,
    Wind
}

[CreateAssetMenu(fileName= "Char_", menuName = "Cards/Character", order = 1)]
public class CharacterSO : ScriptableObject {

    public string charName = "NewChar";
    public Mesh charMesh = null;
    public CharacterType charType = 0;
    public int charPower = 1000;
    public int charHealth = 1000;
    public AttackData[] charAttackData;
    public SkillData[] charSkills;
}
