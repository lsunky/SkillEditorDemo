using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class TestFightPlayerInfo 
{
    public int PlayerId;
    public int PlayerLv;
    public string PlayerName;
    public CampType Camp;
    public List<TestFightRoleData> RoleList;
}
