
public class FrameInfoRoundEnd : FrameInfoBase
{
    public FrameInfoRoundEnd(int startFrame) : base(startFrame)
    {
    }

    public override string ActionToString => $"角色【{RoleUid}】的技能【{SkillId}】小回合结束。";

    public override FrameType FrameType => FrameType.RoundEnd;

    public int SkillId { get; private set; }
    public int RoleUid { get; private set; }
    public void SetInfo(int skillId, int roleUid) 
    {
        this.SkillId = skillId;
        this.RoleUid = roleUid;
    }
}
