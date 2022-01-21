using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightField 
{
    public FightData FightData { get; }
    public FightTeam FightTeamA { get; }
    public FightTeam FightTeamB { get; }

    public List<FightRole> FightRolesAll { get; }
    public List<FightHero> FightHerosAll { get; }
    public List<FightPet> FightPetsAll { get; }
    public Dictionary<bool, FightTeam> Dic_FightTeam { get; }
    public Dictionary<int, FightRole> Dic_FightRoles { get; }

    public Dictionary<int, bool> Dic_SkillAll;
    //区分开IsA只是站在我方视角看到的攻击者，实际上有可能为防守方
    public FightField(FightTeam atkerTeam, FightTeam defenderTeam, FightData fightData) 
    {
        this.FightData = fightData;
        this.FightTeamA = atkerTeam;
        this.FightTeamB = defenderTeam;
        
        if (defenderTeam.ContainsPlayer(fightData.MyPlayerId))
        {
            this.FightTeamA = defenderTeam;
            this.FightTeamB = atkerTeam;
        }

        this.Dic_FightTeam = new Dictionary<bool, FightTeam>()
        {
            [true] = this.FightTeamA,
            [false] = this.FightTeamB
        };
        this.Dic_FightRoles = new Dictionary<int, FightRole>();
        this.FightRolesAll = new List<FightRole>();
        this.FightHerosAll = new List<FightHero>();
        this.FightPetsAll = new List<FightPet>();
        this.Dic_SkillAll = new Dictionary<int, bool>();
        AddByTeam(atkerTeam);
        AddByTeam(defenderTeam);
    }

    private void AddByTeam(FightTeam fightTeam) 
    {
        foreach (var role in fightTeam.FightRoles) 
        {
            Dic_FightRoles.Add(role.Uid, role);
            foreach (var skillId in role.DicSkills.Keys)
            {
                Dic_SkillAll[skillId] = true;
            }
        }
            

        this.FightRolesAll.AddRange(fightTeam.FightRoles);
        this.FightHerosAll.AddRange(fightTeam.FightHeros);
        this.FightPetsAll.AddRange(fightTeam.FightPets);
    }

    public FightRole GetRoleByUid(int roleUid) 
    {
        return Dic_FightRoles[roleUid];
    }

}
