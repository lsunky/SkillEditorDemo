
using GameFramework;
using UnityEngine;

public class FightStatePrepareData : FightStateBase
{
    public override void Enter()
    {
        TestFightData testFightData = Resources.Load<TestFightData>("FightData");
        FightField fightField = FightFieldFactory.CreateFieldByTest(testFightData);
        FightData fightData = fightField.FightData;
        foreach (var skillId in fightField.Dic_SkillAll.Keys)
        {
            if (!fightData.ContainsConfig(skillId))
            {
                fightData.AddConfig(Resources.Load<C_SkillConfig>($"skill{skillId}"));
            }
        }
        Game.FightEvent.FireNow(this, ReferencePool.Acquire<FightFieldCompleteArgs>().RefreshInfo(fightField));
        
    }

}
