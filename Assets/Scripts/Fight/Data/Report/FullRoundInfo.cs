using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullRoundInfo 
{
    public List<RoundInfo> RoundInfos { get; }
    public FullRoundInfo() 
    {
        RoundInfos = new List<RoundInfo>();
    }

    public void AddRoundInfo(RoundInfo roundInfo) => RoundInfos.Add(roundInfo);
}
