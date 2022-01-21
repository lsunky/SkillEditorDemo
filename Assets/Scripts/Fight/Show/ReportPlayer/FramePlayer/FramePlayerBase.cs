using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FramePlayerBase 
{
    protected FrameInfoBase frameInfo;
    protected FightRender fightRender;
    public FramePlayerBase(FrameInfoBase frameInfoBase, FightRender fightRender) 
    { 
        this.frameInfo = frameInfoBase;
        this.fightRender = fightRender;
    }

    public bool WillCache => frameInfo.EndFrame.HasValue;

    public void Exec() 
    {
        this.frameInfo.Print(FrameLogType.Show);
        this.OnExec();
    }
    protected abstract void OnExec();

    public bool Update(int curFrame) 
    {
        this.OnUpdate(curFrame);
        if (curFrame >= frameInfo.EndFrame)
        {
            this.End();
            return true;
        }
        return false;
    }
    protected virtual void OnUpdate(int curFrame) { }

    protected void End() => this.OnEnd();
    protected virtual void OnEnd() { }
}
