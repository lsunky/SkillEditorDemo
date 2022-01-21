using System.Collections.Generic;
public abstract class FightStateBase 
{
    private FightFSM fsm;
    public void Init(FightFSM fsm) 
    {
        this.fsm = fsm;
    }
    protected void ChangeState(FightState iState) => fsm.Change(iState);
    public abstract void Enter();
    public virtual void Exit() { }
}

public class FightFSM 
{
    public FightStateBase pCurState { get; private set; }
    private Dictionary<FightState, FightStateBase> mdicState ;
    public FightFSM() 
    {
        mdicState = new Dictionary<FightState, FightStateBase>();
        this.AddState(FightState.PrepareData, new FightStatePrepareData());
        this.AddState(FightState.PreloadRender, new FightStatePreloadRender());
        this.AddState(FightState.RenderJumpIn, new FightStateRenderJumpIn());
        this.AddState(FightState.ShowUi, new FightStateShowUi());
        this.AddState(FightState.InFight, new FightStateInFight());
        this.AddState(FightState.FightEnd, new FightStateFightEnd());
    }
    public void AddState(FightState id, FightStateBase state) 
    {
        state.Init(this);
        this.mdicState.Add(id, state);
    }
    public void Change(FightState eState) 
    {
        pCurState?.Exit();
        pCurState = mdicState[eState];
        pCurState.Enter();
    }
}
