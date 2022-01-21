
using GameFramework;

public class FightStateInFight : FightStateBase
{
    public override void Enter()
    {
        Game.FightEvent.FireNow(this, ReferencePool.Acquire<RunFightArgs>());
    }
}
