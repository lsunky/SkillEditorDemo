using UnityEngine;
using System.Collections.Generic;
public class FightRole
{
    public delegate void RoleDieHandle(FightRole role);
    public event RoleDieHandle RoleDieEvent;
    public FightRoleData FightRoleData { get; }
    public int Uid => FightRoleData.UId;
    public Dictionary<int, int> DicSkills => FightRoleData.DicSkills;
    public bool IsAlive { get; private set; }

    public Vector2 Position { get; private set; }
    public Vector2 BasePosition { get; private set; }
    public FightRole(FightRoleData roleData)
    {
        IsAlive = true;
        FightRoleData = roleData;
    }

    public void Die() 
    {
        IsAlive = false;
        RoleDieEvent?.Invoke(this); 
    }

    public Vector2 GetJumpPos(FightRole target, MoveTargetType moveTargetType) 
    {
        return target.Position;
    }
}
