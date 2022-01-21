
using GameFramework;

public class FullRoundCmdArgs : BaseEventArgs
{
    public static readonly int EventId = typeof(FullRoundCmdArgs).GetHashCode();
    public override int Id => EventId;
    public FullRoundCmd FullRoundCmd { get; private set; }

    public FullRoundCmdArgs RefreshInfo(FullRoundCmd fullRoundCmd)
    {
        this.FullRoundCmd = fullRoundCmd; 
        return this;
    }

    public override void Clear()
    {
        FullRoundCmd = null;
    }
}
