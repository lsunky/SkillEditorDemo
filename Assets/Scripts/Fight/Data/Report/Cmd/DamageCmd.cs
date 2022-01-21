
public class DamageCmd 
{
    public int TargetUid { get; }
    public int DamageValue { get; }
    public bool IsCrit { get; }
    public bool IsMiss { get; }

    public DamageCmd(TestDamageInfo testDamageInfo) 
    {
        this.TargetUid = testDamageInfo.TargetUid;
        this.DamageValue = testDamageInfo.DamageValue;
        this.IsCrit = testDamageInfo.IsCrit;
        this.IsMiss = testDamageInfo.IsMiss;
    }
}
