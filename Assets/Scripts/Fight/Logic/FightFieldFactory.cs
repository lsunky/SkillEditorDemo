using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FightFieldFactory 
{
    /// <summary>
    /// 通过测试数据还原战场（逻辑层）
    /// </summary>
    /// <param name="testFightData"></param>
    /// <returns></returns>
    public static FightField CreateFieldByTest(TestFightData testFightData) 
    {
        FightTeam fightTeamAtker = new FightTeam();
        FightTeam fightTeamDefener = new FightTeam();
        
        FightPlayer player;
        FightTeam curTeam;
        int myPlayerId = 0 ;
        foreach (var testPlayer in testFightData.PlayerList)
        {
            curTeam = testPlayer.Camp == CampType.Atker ? fightTeamAtker : fightTeamDefener;
            player = new FightPlayer(new FightPlayerInfo(testPlayer));
            curTeam.AddFightPlayer(player);
            if (myPlayerId == 0)
            {
                myPlayerId = player.Info.PlayerId;
            }
        }
        FightField fightField = new FightField(fightTeamAtker, fightTeamDefener, new FightData(myPlayerId));
        return fightField;
    }
}
