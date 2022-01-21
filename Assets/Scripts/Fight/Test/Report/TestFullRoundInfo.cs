using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TestFullRoundInfo : ScriptableObject
{
    public List<TestRoundInfo> RoundInfoList = new List<TestRoundInfo>();
}
