using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_SkillConfig : ScriptableObject
{
    private List<Config_ActionBase> casterActionList;
    public List<Config_ActionBase> CasterActionList
    {
        get 
        {
            if (casterActionList == null)
            {
                casterActionList = ConvertToBaseList(CasterList);
            }
            return casterActionList;
        }
    }

    private List<Config_ActionBase> targetActionList;
    public List<Config_ActionBase> TargetActionList 
    { 
        get 
        {
            if (targetActionList == null)
                targetActionList = ConvertToBaseList(TargetList);
            return targetActionList;
        }
    }
    public int SkillId;
    public List<Config_ActionCommon> CasterList;
    public List<Config_ActionCommon> TargetList;

    private List<Config_ActionBase> ConvertToBaseList(List<Config_ActionCommon> list) 
    {
        List<Config_ActionBase> result = new List<Config_ActionBase>();
        for (int i = 0,length = list.Count; i < length; i++)
        {
            result.Add(list[i].ToActionBase());
        }
        return result;
    }

    public void CreateTestConfig()
    {
        casterActionList = new List<Config_ActionBase>();
        targetActionList = new List<Config_ActionBase>();
        //奔跑动画
        Config_ActionAnim config_ActionAnim = new Config_ActionAnim();
        config_ActionAnim.StartFrame = 1;
        config_ActionAnim.Duration = 100;
        config_ActionAnim.AnimName = "Run_Guard";
        casterActionList.Add(config_ActionAnim);

        //移动
        Config_ActionMove config_ActionMove = new Config_ActionMove();
        config_ActionMove.StartFrame = 1;
        config_ActionMove.Duration = 100;
        config_ActionMove.MoveType = MoveType.JumpTo;
        config_ActionMove.MoveTargetType = MoveTargetType.Front;
        casterActionList.Add(config_ActionMove);

        //攻击
        config_ActionAnim = new Config_ActionAnim();
        config_ActionAnim.StartFrame = 101;
        config_ActionAnim.Duration = 10;
        config_ActionAnim.AnimName = "Shoot_Auto";
        casterActionList.Add(config_ActionAnim);

        //施法特效
        Config_ActionArt config_ActionArt = new Config_ActionArt();
        config_ActionArt.StartFrame = 102;
        config_ActionArt.Duration = 10;
        config_ActionArt.ArtName = "FireArt";
        casterActionList.Add(config_ActionArt);

        //施法音效
        Config_ActionSound config_ActionSound = new Config_ActionSound();
        config_ActionSound.SoundName = "DA~DA~DA~DA";
        config_ActionSound.StartFrame = 103;
        casterActionList.Add(config_ActionSound);

        //受击动画
        config_ActionAnim = new Config_ActionAnim();
        config_ActionAnim.StartFrame = 104;
        config_ActionAnim.Duration = 10;
        config_ActionAnim.AnimName = "Hurt";
        targetActionList.Add(config_ActionAnim);

        //受击特效
        config_ActionArt = new Config_ActionArt();
        config_ActionArt.StartFrame = 104;
        config_ActionArt.Duration = 3;
        config_ActionArt.ArtName = "DmgArt";
        targetActionList.Add(config_ActionArt);

        //飘伤害
        Config_ActionDamage config_ActionDamage = new Config_ActionDamage();
        config_ActionDamage.StartFrame = 104;
        config_ActionDamage.DamageType = DamageType.Pure;
        targetActionList.Add(config_ActionDamage);

        //回家
        config_ActionMove = new Config_ActionMove();
        config_ActionMove.StartFrame = 108;
        config_ActionMove.Duration = 10;
        config_ActionMove.MoveType = MoveType.Back;
        casterActionList.Add(config_ActionMove);
    }
}
