
public class FightStatePreloadRender : FightStateBase
{
    public override void Enter()
    {
        //调用加载战场，角色，预加载战斗特效，加载完成之后，退出此状态
        ChangeState(FightState.RenderJumpIn);
    }
    
}
