using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillActionArt 
{
    public static FrameInfoArt Exec(int roleUid, Config_ActionArt action)
    {
        FrameInfoArt frameInfoArt = new FrameInfoArt(action.StartFrame, action.Duration);
        frameInfoArt.SetInfo(roleUid, false, action.ArtName);
        return frameInfoArt;
    }
}
