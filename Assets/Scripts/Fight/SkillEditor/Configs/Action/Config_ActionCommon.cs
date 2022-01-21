
using System;

[Serializable]
public class Config_ActionCommon 
{
    public SkillActionType SkillActionType;
    public int StartFrame;
    public int Duration;
    public string Name;
    public int Type;
    public int IntArg;

    public Config_ActionCommon(Config_ActionMove action)
    {
        this.SkillActionType = SkillActionType.Move;
        this.StartFrame = action.StartFrame;
        this.Duration = action.Duration;
        this.Type = (int)action.MoveType;
        this.IntArg = (int)action.MoveTargetType;
    }
    public Config_ActionCommon(Config_ActionDamage action) 
    {
        this.SkillActionType    = SkillActionType.Damage;
        this.StartFrame         = action.StartFrame;
        this.Type               = (int)action.DamageType;
    }

    public Config_ActionCommon(Config_ActionAnim action)
    {
        this.SkillActionType    = SkillActionType.Anim;
        this.StartFrame         = action.StartFrame;
        this.Duration           = action.Duration;
        this.Name               = action.AnimName;
    }



    public Config_ActionCommon(Config_ActionArt action) 
    {
        this.SkillActionType    = SkillActionType.Art;
        this.StartFrame         = action.StartFrame;
        this.Duration           = action.Duration;
        this.Name               = action.ArtName;
    }

    public Config_ActionCommon(Config_ActionSound action)
    {
        this.SkillActionType    = SkillActionType.Sound;
        this.StartFrame         = action.StartFrame;
        this.Name               = action.SoundName;
    }
    
    public Config_ActionBase ToActionBase() => this.SkillActionType switch
    {
        SkillActionType.Move => new Config_ActionMove()
        {
            StartFrame      = this.StartFrame,
            Duration        = this.Duration,
            MoveType        = (MoveType)this.Type,
            MoveTargetType  = (MoveTargetType)this.IntArg,
        },
        SkillActionType.Damage =>new Config_ActionDamage() { 
            StartFrame      = this.StartFrame,
            DamageType      = (DamageType)this.Type
        },
        SkillActionType.Anim => new Config_ActionAnim() {  
            StartFrame      = this.StartFrame,
            Duration        = this.Duration,
            AnimName        = this.Name,
        },
        SkillActionType.Art => new Config_ActionArt()
        {
            StartFrame      = this.StartFrame,
            Duration        = this.Duration,
            ArtName         = this.Name,
        },
        SkillActionType.Sound => new Config_ActionSound()
        {
            StartFrame = this.StartFrame,
            SoundName = this.Name,
        },
        _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(SkillActionType))
    };
	
}
