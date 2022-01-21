
using GameFramework;

public class FramePlayerRoundEnd : FramePlayerBase
{
    public FramePlayerRoundEnd(FrameInfoBase frameInfoBase,FightRender fightRender) : base(frameInfoBase, fightRender)
    {

    }

    protected override void OnExec()
    {
        Game.FightEvent.FireNow(this, ReferencePool.Acquire<RoundEndArgs>());
    }

}
