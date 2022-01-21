using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightEmulator 
{
    private FightAtkHanle atkHandle;
    private FightField fightField;
    private FightResult fightResult;

    public bool IsFightEnd => fightResult.result != Result.None;
    public FightEmulator(FightField fightField) 
    {
        this.fightField = fightField;
        this.atkHandle = new FightAtkHanle(fightField);
        this.fightResult = new FightResult(fightField);
    }

    public FullRoundInfo ParseCmd(FullRoundCmd fullRoundCmd) 
    {
        FullRoundInfo fullRoundInfo = new FullRoundInfo();
        var roundInfoList = fullRoundCmd.RoundInfoList;
        RoundCmd roundCmd;
        RoundInfo roundInfo;
        for (int i = 0,length = roundInfoList.Count; i < length; i++)
        {
            roundCmd = roundInfoList[i];
            roundInfo = atkHandle.ParseCmd(roundCmd,fightField.FightData.GetSkillConfig(roundCmd.SkillId));
            fullRoundInfo.AddRoundInfo(roundInfo);
        }
        
        return fullRoundInfo;
    }
}
