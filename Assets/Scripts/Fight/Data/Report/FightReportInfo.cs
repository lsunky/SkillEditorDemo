using System.Collections.Generic;

public class FightReportInfo
{
    public List<FullRoundInfo> FullRoundInfos { get; }
    public FightReportInfo() => FullRoundInfos = new List<FullRoundInfo>();
    public void AddFullRound(FullRoundInfo fullRoundInfo)
    {
        FullRoundInfos.Add(fullRoundInfo);
    }
    

}
