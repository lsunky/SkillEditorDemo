

public static class FramePlayerFactory
{
	//不想写反射，就这样吧
	public static FramePlayerBase CreateFramePlayer(FrameInfoBase frameInfo,FightRender fightRender) => frameInfo.FrameType switch
	{
		FrameType.Move		=> new FramePlayerMove(frameInfo, fightRender),
		FrameType.Damage	=> new FramePlayerDamage(frameInfo, fightRender),
		FrameType.Anim		=> new FramePlayerAnim(frameInfo, fightRender),
		FrameType.Art		=> new FramePlayerArt(frameInfo, fightRender),
		FrameType.Sound		=> new FramePlayerSound(frameInfo, fightRender),
		FrameType.RoundEnd	=> new FramePlayerRoundEnd(frameInfo, fightRender),
		_ => null,
	};
}
