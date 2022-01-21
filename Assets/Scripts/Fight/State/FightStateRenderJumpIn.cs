
public class FightStateRenderJumpIn : FightStateBase
{
    public override void Enter()
    {
        //调用render层角色跳入动画，执行完成后切换ui
        this.ChangeState(FightState.ShowUi);
    }
}
