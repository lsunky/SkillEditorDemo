using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameInfoAnim : FrameInfoBase
{
    public FrameInfoAnim(int startFrame, int duration) : base(startFrame, duration)
    {
    }

    public override string ActionToString
    {
        get 
        {
            return $"角色【{this.RoleUid}】 增加了动画【{this.AnimationName}】"; 
        }
    }

    public override FrameType FrameType => FrameType.Anim;

    public int RoleUid { get; private set; }
    public string AnimationName { get; private set; }

    public void SetInfo(int roleUid,string animationName) 
    {
        this.RoleUid        = roleUid;
        this.AnimationName  = animationName; 
    }

}
