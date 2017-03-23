using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "Support_", menuName = "Cards/Support", order = 1)]
public class SupportSO : ScriptableObject {

    public string supportName = "NewSupport";
    public AttackType supportEnhance = AttackType.QUICK;
    public int supportFocus = 1000;
    public int supportDefense = 1000;
    public SkillData[] supportSkills;

}
