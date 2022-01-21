using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSkillHandle 
{
    private FightField fightField;
    public FightSkillHandle(FightField fightField) 
    {
        this.fightField = fightField;
    }
    
    public RoundInfo ParseCmd(RoundCmd roundCmd, C_SkillConfig c_SkillConfig)
    {
        RoundInfo roundInfo = new RoundInfo();
        var actionList = c_SkillConfig.CasterActionList;

        Config_ActionBase config_ActionBase = null;
        FrameInfoBase frameInfo = null;
        for (int i = 0, length = actionList.Count; i < length; i++)
        {
            config_ActionBase = actionList[i];
            if (config_ActionBase is Config_ActionArt)
            {
                frameInfo = SkillActionArt.Exec(roundCmd.RoleUid, (Config_ActionArt)config_ActionBase);
            }
            else if (config_ActionBase is Config_ActionAnim)
            {
                frameInfo = SkillActionAnim.Exec(roundCmd.RoleUid, (Config_ActionAnim)config_ActionBase);
            }else if (config_ActionBase is Config_ActionMove)
            {
                int mainTargetId = roundCmd.Damages[0].TargetUid;
                frameInfo = SkillActionMove.Exec(fightField.GetRoleByUid(roundCmd.RoleUid), fightField.GetRoleByUid(mainTargetId), (Config_ActionMove)config_ActionBase);
            }
            else if (config_ActionBase is Config_ActionSound)
            {
                frameInfo = SkillActionSound.Exec((Config_ActionSound)config_ActionBase);
            }
            else
            {
                throw new System.Exception("Invalid Type Config Action");
            }
            roundInfo.AddFrameInfo(frameInfo);
        }

        actionList = c_SkillConfig.TargetActionList;
        var damages = roundCmd.Damages;
        DamageCmd dmageCmd;
        for (int i = 0,length = actionList.Count; i < length; i++)
        {
            config_ActionBase = actionList[i];
            for (int j = 0,dmgLth = damages.Count; j < dmgLth; j++)
            {
                dmageCmd = damages[j];
                frameInfo = null;
                if (!dmageCmd.IsMiss)
                {
                    if (config_ActionBase is Config_ActionArt)
                    {
                        frameInfo = SkillActionArt.Exec(dmageCmd.TargetUid, (Config_ActionArt)config_ActionBase);
                    }
                    else if (config_ActionBase is Config_ActionAnim)
                    {
                        frameInfo = SkillActionAnim.Exec(dmageCmd.TargetUid, (Config_ActionAnim)config_ActionBase);
                    }
                    else if (config_ActionBase is Config_ActionSound)
                    {
                        frameInfo = SkillActionSound.Exec((Config_ActionSound)config_ActionBase);
                    }
                }

                if (config_ActionBase is Config_ActionDamage)
                {
                    frameInfo = SkillActionDamage.Exec((Config_ActionDamage)config_ActionBase, dmageCmd);
                }
                else if (frameInfo == null && !dmageCmd.IsMiss)
                {
                    throw new System.Exception("Invalid Type Config Action");
                }
                if (frameInfo != null)
                    roundInfo.AddFrameInfo(frameInfo);
            }
        }

        frameInfo = SkillActionRoundEnd.Exec(roundInfo.GetEndFrame(), roundCmd.SkillId, roundCmd.RoleUid);
        roundInfo.AddFrameInfo(frameInfo);

        roundInfo.Sort();
        roundInfo.Print(FrameLogType.Logic);
        return roundInfo;
    }

}
