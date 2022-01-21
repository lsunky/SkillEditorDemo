using GameFramework;

public class RunFightArgs : BaseEventArgs
{
    public static readonly int EventId = typeof(RunFightArgs).GetHashCode();
    public override int Id => EventId;

    public override void Clear()
    {

    }
}
