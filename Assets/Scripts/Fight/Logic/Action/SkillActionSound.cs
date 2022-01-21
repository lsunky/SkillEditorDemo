
public class SkillActionSound 
{
    public static FrameInfoBase Exec( Config_ActionSound action)
    {
        FrameInfoSound frameInfoSound = new FrameInfoSound(action.StartFrame);
        frameInfoSound.SetInfo(action.SoundName);
        return frameInfoSound;
    }
}
