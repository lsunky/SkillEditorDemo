
public class FightStateShowUi : FightStateBase
{
    public override void Enter()
    {
        this.ChangeState(FightState.InFight);
    }
}
