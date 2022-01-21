using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightRoleData 
{
    public int UId;
    public int BaseId;
    public List<int> Attr;
    public Dictionary<int, int> DicSkills;
    public FightRoleData(TestFightRoleData testRole) 
    {
        this.UId = testRole.UId;
        this.BaseId = testRole.BaseId; 
        this.Attr = new List<int>();
        this.DicSkills = new Dictionary<int, int>();
        TestSkillInfo testSkillInfo;
        for (int i = 0,length = testRole.Skills.Count; i < length; i++)
        {
            testSkillInfo = testRole.Skills[i];
            DicSkills[testSkillInfo.SkillId] = testSkillInfo.SkillLv;
        }
    }
}
