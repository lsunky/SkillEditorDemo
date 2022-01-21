
using UnityEngine;
using UnityEngine.Playables;
public class SkillDamagePlayable : PlayableAsset
{
    public DamageType DamageType;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<SkillDamagePlayableBehaviour>.Create(graph);
        SkillDamagePlayableBehaviour behaviour = playable.GetBehaviour();
        behaviour.DamageType = DamageType;
        return playable;
    }
}

public class SkillDamagePlayableBehaviour : PlayableBehaviour 
{
    public DamageType DamageType;
}