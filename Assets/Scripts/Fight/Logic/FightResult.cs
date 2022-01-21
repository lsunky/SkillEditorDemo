using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightResult
{
    public Result result;

    public bool HasEnd => result != Result.None;
    private FightField fightField;
    public FightResult(FightField fightField)
    {
        this.fightField = fightField;

        fightField.FightTeamA.TeamDieAllEvent += TeamDieAllHandle;
    }

    private void TeamDieAllHandle(FightTeam fightTeam) 
    {
        result = fightTeam.IsA ? Result.DefenderWin : Result.AtkerWin;
    }

}
