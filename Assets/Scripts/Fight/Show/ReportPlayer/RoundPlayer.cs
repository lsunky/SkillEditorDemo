using System.Collections.Generic;
public class RoundPlayer 
{
    private int nextFrameIndex;
    private int nextFrame;
    private List<FramePlayerBase> framePlayerList;
    private int curFrame;
    private RoundInfo m_RoundInfo;
    private FightRender fightRender;
    public RoundPlayer(RoundInfo roundInfo, FightRender fightRender) 
    {
        this.fightRender = fightRender;
        this.m_RoundInfo = roundInfo;
        this.framePlayerList = new List<FramePlayerBase>();
        PlayOneFrame();
    } 

    public void FixedUpdate() 
    {
        curFrame ++;
        if (nextFrame == curFrame) PlayOneFrame();

        for (int i = framePlayerList.Count-1; i > 0; i--)
        {
            if (framePlayerList[i].Update(curFrame)) 
                framePlayerList.RemoveAt(i);
        }
    }

    private void PlayOneFrame() 
    {
        FrameInfoBase frameInfo;
        for (int i = nextFrameIndex; i < m_RoundInfo.FrameInfos.Count; i++)
        {
            frameInfo = m_RoundInfo.FrameInfos[i];
            if (frameInfo.StartFrame == curFrame) PlayOneFrameInfo(frameInfo);
            else 
            {
                nextFrame = frameInfo.StartFrame;
                nextFrameIndex = i;
                break;
            }
        }
    }

    private void PlayOneFrameInfo(FrameInfoBase frameInfo) 
    {
        var frameReport = FramePlayerFactory.CreateFramePlayer(frameInfo,this.fightRender);
        if (frameInfo.EndFrame.HasValue) framePlayerList.Add(frameReport);
        frameReport.Exec();
    }

}
