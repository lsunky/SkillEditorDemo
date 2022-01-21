using GameFramework;
using GameFramework.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FightTestMain : MonoBehaviour
{
    FightMain fightMain = null;
    PlayableDirector playable;
    public FightRender fightRender;
    private void Start()
    {
        fightMain = new FightMain(fightRender);
    }

    private void FixedUpdate()
    {
        fightMain.FixedUpdate();
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(150f,200,300,200),"模拟服务器战报"))
        {
            TestFullRoundInfo testFullRound = Resources.Load<TestFullRoundInfo>("FullRound");
            FullRoundCmd fullRoundCmd = new FullRoundCmd(testFullRound);
            Game.FightEvent.FireNow(this, ReferencePool.Acquire<FullRoundCmdArgs>().RefreshInfo(fullRoundCmd));
        }
    }
}
