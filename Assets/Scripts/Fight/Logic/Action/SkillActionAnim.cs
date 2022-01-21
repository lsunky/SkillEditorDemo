
public class SkillActionAnim
{
    public static FrameInfoAnim Exec(int roleUid,Config_ActionAnim action)
    {
        FrameInfoAnim frameInfoAnim = new FrameInfoAnim(action.StartFrame, action.Duration);
        frameInfoAnim.SetInfo(roleUid,action.AnimName);
        return frameInfoAnim;
    }
}
