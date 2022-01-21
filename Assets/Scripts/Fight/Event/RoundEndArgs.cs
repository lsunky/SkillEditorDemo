
using GameFramework;

public class RoundEndArgs : BaseEventArgs
{
    public static readonly int EventId = typeof(RoundEndArgs).GetHashCode();
    public override int Id => EventId;

    public override void Clear()
    {
    }
}
