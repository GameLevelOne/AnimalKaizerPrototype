using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyCombination
{
    public CharacterSO main;
    public SupportSO support;
    public SpecialMoveSO specialMove;
}

[CreateAssetMenu(fileName = "EnemyList", menuName = "Cards/EnemyList", order = 1)]
public class EnemyListSO : ScriptableObject {

    public EnemyCombination[] enemy;

    public Character GetRandomEnemy()
    {
        int randomIndex = Random.Range(0, enemy.Length);
        Character newChar = new Character(enemy[randomIndex].main);
        newChar.Combine(new Support(enemy[randomIndex].support));
        newChar.Combine(new SpecialMove(enemy[randomIndex].specialMove));
        return newChar;
    }
}
