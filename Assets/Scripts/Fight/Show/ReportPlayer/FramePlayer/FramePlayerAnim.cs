
public class FramePlayerAnim : FramePlayerBase
{
    public FramePlayerAnim(FrameInfoBase frameInfoBase, FightRender fightRender) : base(frameInfoBase, fightRender)
    {

    }

    protected override void OnExec()
    {
        FrameInfoAnim frameInfoAnim = (FrameInfoAnim)frameInfo;
        this.fightRender.PlayAnim(frameInfoAnim.RoleUid,frameInfoAnim.AnimationName);
    }

}
