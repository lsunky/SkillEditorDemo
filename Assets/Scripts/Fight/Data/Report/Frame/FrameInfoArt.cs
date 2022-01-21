

public class FrameInfoArt : FrameInfoBase
{
    //创建或者销毁特效,durationFrame不为-1的时候是自动销毁，在技能回合结束时候Destroy，为-1的时候等逻辑主动销毁
    public FrameInfoArt(int startFrame, int duration) : base(startFrame, duration)
    {
    }

    public override string ActionToString 
    {
        get 
        {
            string addDes = this.IsRemove ? "移除" : "添加";
            if (!this.IsRemove)
                return $"角色【{this.RoleUid}】{addDes}了特效【{this.ArtName}】 结束时间为【{this.EndFrame}】";
            else
                return $"角色【{this.RoleUid}】{addDes}了特效【{this.ArtName}】 ";
        }
    }

    public override FrameType FrameType => FrameType.Art;

    public int RoleUid { get; private set; }
    public bool IsRemove { get; private set; }
    public string ArtName { get; private set; }
    public void SetInfo(int roleUid, bool isRemove,string artName) 
    {
        this.RoleUid = roleUid;
        this.IsRemove = isRemove;
        this.ArtName = artName;
    }

}
