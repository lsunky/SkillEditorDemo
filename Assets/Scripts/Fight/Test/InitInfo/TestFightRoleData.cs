using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class TestFightRoleData 
{
    public int UId;
    public int PosId;
    public int BaseId;
    public List<int> Attr;
    public List<TestSkillInfo> Skills;
}
