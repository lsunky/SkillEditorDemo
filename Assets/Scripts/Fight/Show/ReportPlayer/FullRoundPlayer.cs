
using System.Collections.Generic;
public class FullRoundPlayer 
{
    private FullRoundInfo m_FullRoundInfo;
    private RoundPlayer m_RoundPlayer;
    private int m_RoundIndex;
    private FightRender fightRender;
    public FullRoundPlayer(FullRoundInfo fullRoundInfo, FightRender fightRender) 
    {
        this.fightRender = fightRender;
        this.m_FullRoundInfo = fullRoundInfo;
        if (HasNext) Next();
    }
    public bool HasNext => m_FullRoundInfo.RoundInfos.Count > m_RoundIndex;
    public void Next() => m_RoundPlayer = new RoundPlayer(m_FullRoundInfo.RoundInfos[m_RoundIndex++],this.fightRender);
    public void FixedUpdate() => m_RoundPlayer.FixedUpdate();
}
