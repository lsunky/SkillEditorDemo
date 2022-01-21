using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillActionDamage 
{
    public static FrameInfoBase Exec(Config_ActionDamage action, DamageCmd damageCmd) 
    {
        FrameInfoDamage frameInfoDamage = new FrameInfoDamage(action.StartFrame);
        frameInfoDamage.SetInfo(damageCmd.TargetUid, damageCmd.DamageValue,damageCmd.IsCrit,damageCmd.IsMiss, action.DamageType);
        return frameInfoDamage;
    }

}
