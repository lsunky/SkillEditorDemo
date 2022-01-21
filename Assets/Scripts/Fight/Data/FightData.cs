using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightData
{
    /// <summary>
    /// 以此人为第一视角
    /// </summary>
    public int MyPlayerId { get; }

    public FightData(int myPlayerId) 
    {
        MyPlayerId = myPlayerId;
    }
    private Dictionary<int,C_SkillConfig> skillConfigs = new Dictionary<int, C_SkillConfig>();

    public void AddConfig(C_SkillConfig c_SkillConfig) => skillConfigs[c_SkillConfig.SkillId] = c_SkillConfig;
    public bool ContainsConfig(int skillId) => skillConfigs.ContainsKey(skillId);
    public C_SkillConfig GetSkillConfig(int skillId) => skillConfigs[skillId]; 
}
