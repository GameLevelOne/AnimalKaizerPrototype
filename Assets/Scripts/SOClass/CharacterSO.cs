using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "Char_", menuName = "Cards/Character", order = 1)]
public class CharacterSO : ScriptableObject {

    public string charName = "NewChar";
    public Mesh charMesh = null;
    public int charPower = 1000;
    public int charHealth = 1000;
    public AttackData[] charAttackData;
    public AbilityData[] charAbility;

}
