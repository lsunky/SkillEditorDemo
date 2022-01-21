using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FrameInfoBase 
{
    private string GetTitle => $"{this.GetType().ToString()}    ÔÚµÚ¡¾{StartFrame}¡¿Ö¡:    ";
    public abstract string ActionToString { get; }
    public abstract FrameType FrameType { get; }
    public int StartFrame { get; }
    public int? EndFrame { get; }
    public FrameInfoBase(int startFrame) => this.StartFrame = startFrame;
    public int LastFrame { 
        get 
        {
            if (EndFrame.HasValue && EndFrame > StartFrame)
            {
                return EndFrame.Value;
            }
            return StartFrame;
        }
    }

    public FrameInfoBase(int startFrame, int duration)
    {
        this.StartFrame = startFrame;
        this.EndFrame   = startFrame + duration;
    }
    public void Print(FrameLogType logType) 
    {
        if (logType == FightConst.FrameLogType)
            Debug.Log($"{GetTitle}{ActionToString}");
    }
}
