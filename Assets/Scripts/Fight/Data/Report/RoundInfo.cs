using System.Collections.Generic;
public class RoundInfo 
{
    public List<FrameInfoBase> FrameInfos { get; }
    public RoundInfo()=> FrameInfos = new List<FrameInfoBase>();
    private int? skillEndFrame = null;
    public void AddFrameInfo(FrameInfoBase frameInfo) 
    {
        FrameInfos.Add(frameInfo);
    }

    public void Sort() 
    {
        FrameInfos.Sort((a,b)=>a.StartFrame-b.StartFrame);
    }

    public int GetEndFrame() 
    {
        if (skillEndFrame.HasValue)
            return skillEndFrame.Value;

        int tempLastFrame;
        for (int i = 0,length = FrameInfos.Count; i < length; i++)
        {
            tempLastFrame = FrameInfos[i].LastFrame;
            if (!skillEndFrame.HasValue || skillEndFrame.Value < tempLastFrame)
                skillEndFrame = tempLastFrame;
        }
        if (!skillEndFrame.HasValue)
            skillEndFrame = 0;

        return skillEndFrame.Value;
    }

    public void Print(FrameLogType frameLogType) 
    {
        for (int i = 0, length = FrameInfos.Count; i < length; i++)
        {
            FrameInfos[i].Print(frameLogType);
        }
    }
}
