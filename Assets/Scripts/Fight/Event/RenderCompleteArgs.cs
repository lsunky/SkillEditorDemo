using GameFramework;
using GameFramework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderCompleteArgs : BaseEventArgs
{
    public static readonly int EventId = typeof(RenderCompleteArgs).GetHashCode();
    public override int Id => EventId;

    public override void Clear()
    {
        
    }
}
