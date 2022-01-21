
public class FramePlayerArt : FramePlayerBase
{
    public FramePlayerArt(FrameInfoBase frameInfoBase, FightRender fightRender) : base(frameInfoBase, fightRender)
    {

    }

    protected override void OnExec()
    {
        FrameInfoArt frameInfoArt = (FrameInfoArt)frameInfo;
        fightRender.CreateArt(frameInfoArt.ArtName);
    }

}
