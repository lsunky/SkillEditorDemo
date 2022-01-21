using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightPlayerInfo 
{
    public int PlayerId;
    public int PlayerLv;
    public string PlayerName;
    public CampType Camp;
    public List<FightRoleData> RoleList;
    public FightPlayerInfo(TestFightPlayerInfo fightPlayerInfo) 
    {
        this.PlayerId = fightPlayerInfo.PlayerId;
        this.PlayerLv = fightPlayerInfo.PlayerLv;
        this.PlayerName = fightPlayerInfo.PlayerName;
        this.Camp = fightPlayerInfo.Camp;
        this.RoleList = new List<FightRoleData>();
        foreach (var role in fightPlayerInfo.RoleList)
        {
            this.RoleList.Add(new FightRoleData(role));
        }
    }
}
