using UnityEngine;
using UnityEngine.Playables;

public class SkillMovePlayable : PlayableAsset
{
    public MoveTargetType MoveTargetType;
    public MoveType MoveType;
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<SkillMovePlayableBehaviour>.Create(graph);
        SkillMovePlayableBehaviour behaviour = playable.GetBehaviour();
        behaviour.MoveTargetType = MoveTargetType;
        behaviour.MoveType = MoveType;
        return playable;
    }
}

public class SkillMovePlayableBehaviour : PlayableBehaviour
{
    public MoveTargetType MoveTargetType;
    public MoveType MoveType;
}