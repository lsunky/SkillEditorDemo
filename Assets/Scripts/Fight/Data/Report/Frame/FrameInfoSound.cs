
public class FrameInfoSound : FrameInfoBase
{
    public FrameInfoSound(int startFrame) : base(startFrame)
    {
    }

    public override string ActionToString => $"²¥·ÅÉùÒô¡¾{this.SoundName}¡¿";

    public override FrameType FrameType => FrameType.Sound;
    public string SoundName { get; private set; }
    public void SetInfo(string soundName) 
    {
        this.SoundName = soundName;
    }
}
