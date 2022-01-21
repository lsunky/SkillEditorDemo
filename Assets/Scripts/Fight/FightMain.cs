using GameFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightMain 
{
    FightReportPlayer reportPlayer;
    FightReportInfo reportInfo;
    FightFSM fsm ;
    FightField fightField;
    private FightTick fightTick;
    FightEmulator emulator;
    FightRender fightRender;
    public FightMain(FightRender fightRender) 
    {
        this.fightRender = fightRender;
        fsm = new FightFSM();
        Game.FightEvent.Subscribe(FightFieldCompleteArgs.EventId, FightFieldCompleteHandle);
        Game.FightEvent.Subscribe(RunFightArgs.EventId, RunFightHandle);
        Game.FightEvent.Subscribe(FullRoundCmdArgs.EventId, FullRoundCmdHandle);
        Game.FightEvent.Subscribe(RoundEndArgs.EventId, RoundEndHandle);
        fsm.Change(FightState.PrepareData);
    }

    private void RoundEndHandle(object sender, BaseEventArgs e)
    {
        ReportRoundEndHandle();
    }

    private void FightFieldCompleteHandle(object sender, BaseEventArgs e) 
    {
        fightField = (e as FightFieldCompleteArgs).FightField;
        emulator = new FightEmulator(fightField);
        reportInfo = new FightReportInfo();
        reportPlayer = new FightReportPlayer(reportInfo, fightRender);
        fsm.Change(FightState.PreloadRender);
    }

    private void RunFightHandle(object sender, BaseEventArgs e)
    {
        ReportRoundEndHandle();
        reportPlayer.NeedUpdate = true;
    }

    public void FixedUpdate() 
    {
        if (!reportPlayer.NeedUpdate)
        {
            return;
        }
        reportPlayer.FixedUpdate();
    }

    public void Clear() 
    {
        Game.FightEvent.Unsubscribe(FightFieldCompleteArgs.EventId, FightFieldCompleteHandle);
        Game.FightEvent.Unsubscribe(RunFightArgs.EventId, RunFightHandle);
        Game.FightEvent.Unsubscribe(FullRoundCmdArgs.EventId, FullRoundCmdHandle);
    }

    private void FullRoundCmdHandle(object sender, BaseEventArgs e)
    {
        FullRoundCmdArgs arg = (FullRoundCmdArgs)e;
        FullRoundInfo fullRoundInfo = emulator.ParseCmd(arg.FullRoundCmd);
        reportInfo.AddFullRound(fullRoundInfo);
        ReportRoundEndHandle();
    }

    private void FightEndHandle() 
    {
        fsm.Change(FightState.FightEnd);
    }

    private void ReportRoundEndHandle() 
    {
        if (emulator.IsFightEnd)
        {
            FightEndHandle();
            return;
        }

        if (reportPlayer.HasNext)
        {
            fightTick = FightTick.Play;
            reportPlayer.Next();
        }
        else
            fightTick = FightTick.Strategy;
    }
}
