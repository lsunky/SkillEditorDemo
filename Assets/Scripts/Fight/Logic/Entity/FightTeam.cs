using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FightRole;

public class FightTeam 
{
    public List<FightPlayer> FightPlayers { get; }
    public List<FightRole> FightRoles { get; }
    public List<FightHero> FightHeros { get; }
    public List<FightPet> FightPets { get; }
    private List<int> listPlayerIds;


    public delegate void TeamDieAllDel(FightTeam fightTeam);
    public event TeamDieAllDel TeamDieAllEvent;
    private int aliveCount;
    public bool IsA;
    public FightTeam() 
    {
        this.FightPlayers = new List<FightPlayer>();
        this.FightRoles = new List<FightRole>();
        this.FightHeros = new List<FightHero>();
        this.FightPets = new List<FightPet>();
        this.listPlayerIds = new List<int>();
    }

    public void AddFightPlayer(FightPlayer player) 
    {
        this.listPlayerIds.Add(player.Info.PlayerId);
        this.FightPlayers.Add(player);
        this.FightRoles.AddRange(player.FightRoles);
        this.FightHeros.AddRange(player.FightHeros);
        this.FightPets.AddRange(player.FightPets);
        this.aliveCount += player.FightRoles.Count; 
        var tempList = player.FightHeros;
        for (int i = 0, length = tempList.Count; i < length; i++)
        {
            tempList[i].RoleDieEvent += RoleDieHandle;
        }
    }

    private void RoleDieHandle(FightRole role) 
    {
        this.aliveCount--;
        if (aliveCount == 0)
        {
            TeamDieAllEvent?.Invoke(this);
        }
    }

    public bool ContainsPlayer(int playerId) => listPlayerIds.Contains(playerId);
}
