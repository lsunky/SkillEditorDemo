
using System.Collections.Generic;

public class FullRoundCmd 
{
    public List<RoundCmd> RoundInfoList { get; }
    public FullRoundCmd(TestFullRoundInfo testFullRoundInfo) 
    {
        RoundInfoList = new List<RoundCmd>();
        for (int i = 0, length = testFullRoundInfo.RoundInfoList.Count; i < length; i++)
        {
            RoundInfoList.Add(new RoundCmd(testFullRoundInfo.RoundInfoList[i]));
        }
    }
}
