
using UnityEngine;

public class SkillActionRoundEnd
{
    public static FrameInfoRoundEnd Exec(int curFrame,int skillId,int roleUid)
    {
        FrameInfoRoundEnd frameInfoRoundEnd = new FrameInfoRoundEnd(curFrame + FightConst.RoundInterval);
        frameInfoRoundEnd.SetInfo(skillId,roleUid);
        return frameInfoRoundEnd;
    }
}
