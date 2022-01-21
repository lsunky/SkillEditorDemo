using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillActionMove 
{
    public static FrameInfoMove Exec(FightRole fightRole,FightRole targetRole, Config_ActionMove action)
    {
        FrameInfoMove frameInfoMove = new FrameInfoMove(action.StartFrame, action.Duration);
        if (action.MoveType == MoveType.JumpTo)
            frameInfoMove.SetInfo(fightRole.Uid, fightRole.Position, fightRole.GetJumpPos(targetRole, action.MoveTargetType), action.MoveType);
        else
            frameInfoMove.SetInfo(fightRole.Uid, fightRole.Position, fightRole.BasePosition, action.MoveType);
        return frameInfoMove;
    }
}
