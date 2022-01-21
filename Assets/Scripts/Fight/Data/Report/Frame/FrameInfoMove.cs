using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameInfoMove : FrameInfoBase
{
    public FrameInfoMove(int startFrame, int duration) : base(startFrame, duration)
    {
    }
   
    public override string ActionToString 
    {
        get 
        {
            string moveType = this.MoveType == MoveType.JumpTo ? "跳到" : "回到";
            return $"角色【{this.RoleUid}】 从位置【{StartNodePos.ToString()}】{moveType}【{EndNodePos.ToString()}】   第【{EndFrame}】帧结束。";
        }
    } 

    public override FrameType FrameType => FrameType.Move;

    public int RoleUid { get; private set; }
    public Vector2 StartNodePos { get; private set; }
    public Vector2 EndNodePos { get; private set; }

    public MoveType MoveType { get; private set; }

    public void SetInfo(int roleUid,Vector2 startNodePos,Vector2 endNodePos,MoveType moveType) 
    {
        this.RoleUid        = roleUid;
        this.StartNodePos   = startNodePos;
        this.EndNodePos     = endNodePos;
        this.MoveType       = moveType;
    }
}
