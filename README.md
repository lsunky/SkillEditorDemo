# Editor
## 使用
显示 FightTestMain 隐藏 skill987654 为技能正式播放的演示
显示 skill987654 隐藏 FightTestMain 为技能编辑器的简单演示
菜单目录如下
GameTools -> 测试
GameTools -> 导出技能
GameTools -> 创建技能
## 创建
创建技能，需要输入技能id
创建完以后，生成一个prefab文件，一个timeline文件，在skillRes目录下
## 编辑


选中我们创建好的技能时间轴，编辑时间轴。
拖动我们模型动画到animation的track，则生成对应动画action，
拖动一个Activation track，来控制特效显隐
创建一个playable track，来控制受伤时间点
## 导出
导出以后，会生成一个.asset文件，
游戏运行的时候，在FightStatePrepareData里加载此技能。

# 运行时
在场景里隐藏技能，显示fightTestMain，运行游戏，点击【模拟服务器战报】则开始播放演示。

# 编辑器运行整体思路
### 编辑器层
SkillEditor\Configs\Action
在此目录里把timeline里各个节点生成对应的action，保存到技能配置里。
### logic层
Fight\Logic\Action
逻辑层把不同类型的行为配置解析好，并赋上运行时的角色信息。
### 战报播放器
Fight\Data\Report\Frame
战报播放器负责驱动刷新帧，控制角色在第n帧做事情a，第m帧做事情b，并在对应时间驱动界面刷新。
### 服务器cmd
Fight\Data\Report\Cmd
模拟服务器cmd（伤害处理，前端做战斗的话也可以，这部分就是伤害处理部分），在logic层和config一起结合形成对应的逻辑层数据。


# SkillEditorDemo
