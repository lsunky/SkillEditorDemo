using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightPlayer 
{
    public FightPlayerInfo Info;
    public List<FightRole> FightRoles;
    public List<FightHero> FightHeros;
    public List<FightPet> FightPets;
    public FightPlayer(FightPlayerInfo info) 
    {
        this.Info = info;
        this.FightRoles = new List<FightRole>();
        this.FightHeros = new List<FightHero>(); 
        this.FightPets = new List<FightPet>();
        foreach (var roleData in info.RoleList)
            this.AddFightRole(new FightRole(roleData));

    }
    private void AddFightRole(FightRole fightRole) 
    {
        FightRoles.Add(fightRole);
        if (fightRole is FightHero) FightHeros.Add((FightHero)fightRole);
        if (fightRole is FightPet) FightPets.Add((FightPet)fightRole);
    }
}
