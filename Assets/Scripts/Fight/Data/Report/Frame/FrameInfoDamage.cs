using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameInfoDamage : FrameInfoBase
{
    public FrameInfoDamage(int startFrame) : base(startFrame)
    {
    }

    public override string ActionToString 
    {
        get 
        {
            if (this.IsCrit)
                return $"角色【{this.RoleUid}】被暴击，伤害类型为【{this.DamageType.ToString()}】    伤害值为【{this.DamageValue}】";
            else if (this.IsMiss)
                return $"角色【{this.RoleUid}】Miss了伤害，伤害类型为【{this.DamageType.ToString()}】";
            else
                return $"角色【{this.RoleUid}】受到了伤害，伤害类型为【{this.DamageType.ToString()}】    伤害值为【{this.DamageValue}】";

        }
    } 

    public override FrameType FrameType => FrameType.Damage;

    public int RoleUid { get; private set; }
    public int DamageValue { get; private set; }
    public bool IsCrit { get; private set; }
    public bool IsMiss { get; private set; }
    public DamageType DamageType { get; private set; }
    public void SetInfo(int roleUid,int damageValue,bool isCrit,bool isMiss,DamageType damageType) 
    {
        this.RoleUid        = roleUid;
        this.DamageValue    = damageValue;
        this.IsCrit         = isCrit;
        this.IsMiss         = isMiss;
        this.DamageType     = damageType;
    }
}
