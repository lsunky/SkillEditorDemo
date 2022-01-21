
using GameFramework;

public class FightFieldCompleteArgs : BaseEventArgs
{
    public FightField FightField { get; private set; }
    public static readonly int EventId = typeof(FightFieldCompleteArgs).GetHashCode();
    public override int Id => EventId;

    public FightFieldCompleteArgs RefreshInfo(FightField fightField) 
    {
        this.FightField = fightField;
        return this;
    }

    public override void Clear()
    {
        this.FightField = null;
    }
}
