
public class FightReportPlayer
{
    private FightReportInfo m_FightReportInfo;
    private FullRoundPlayer m_FullRoundPlayer;
    private int m_FullRoundIndex;
    private FightRender fightRender;
    public FightReportPlayer(FightReportInfo fightReportInfo,FightRender fightRender) 
    {   
        this.fightRender = fightRender;
        this.m_FightReportInfo = fightReportInfo;
        if (HasNext) Next();
    }
    public bool HasNext 
    {
        get 
        {
            return (this.m_FullRoundIndex < this.m_FightReportInfo.FullRoundInfos.Count) || (this.m_FullRoundPlayer!=null && this.m_FullRoundPlayer.HasNext);
        }
    } 
    public bool NeedUpdate;

    public void FixedUpdate() 
    {
        if (!NeedUpdate) return;
        this.m_FullRoundPlayer?.FixedUpdate();
    }

    public void Next()
    {
        if (this.m_FullRoundPlayer != null && this.m_FullRoundPlayer.HasNext)
            this.m_FullRoundPlayer.Next();
        else
            this.m_FullRoundPlayer = new FullRoundPlayer(m_FightReportInfo.FullRoundInfos[m_FullRoundIndex++], fightRender);
    }

}
