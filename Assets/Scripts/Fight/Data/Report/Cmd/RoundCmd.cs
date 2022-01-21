
using System.Collections.Generic;

public class RoundCmd 
{
    public int RoleUid { get; }
    public int SkillId { get; }
    public List<DamageCmd> Damages { get; }
    public int Paragraph;
    public RoundCmd(TestRoundInfo testRoundInfo) 
    {
        this.RoleUid = testRoundInfo.RoleUid;
        this.SkillId = testRoundInfo.SkillId;
        this.Damages = new List<DamageCmd>();
        this.Paragraph = testRoundInfo.Paragraph;
        for (int i = 0,length = testRoundInfo.Damages.Count; i < length; i++)
        {
            this.Damages.Add(new DamageCmd(testRoundInfo.Damages[i]));
        }
    }
}
