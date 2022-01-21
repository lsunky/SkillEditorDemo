using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SkillConfigTool 
{
    public static string MarkersTrackName = "Markers";
    public static string AtkStrTag = "Atk";
    public static string DefStrTag = "Def";
    private static int ParseToFrame(double secondTime)
    {
        return Mathf.RoundToInt((float)secondTime * 30f);
    }

    private static string GetSkillName(int skillId) => $"skill{skillId}";
    private static string GetSkillLocalPath(string skillName) => $"Assets/SkillRes/Prefab/{skillName}.prefab";
    private static string GetTimelineLocalPath(string skillName) => $"Assets/SkillRes/TimeLine/{skillName}TimeLine.playable";
    private static bool TryGetSkillIdByTimelineName(string timeLineName,out int skillId) 
    {
        string strId = timeLineName.Substring(5, timeLineName.Length - 13);
        if (int.TryParse(strId, out int tempId)) 
        {
            skillId = tempId; return true;
        }
        skillId = 0;
        return false;
    }

    private static void DoCreateTimeLine(string skillName) 
    {
        string localPath = GetTimelineLocalPath(skillName);
        var asset = TimelineAsset.CreateInstance<TimelineAsset>();
        AssetDatabase.CreateAsset(asset, localPath);
        GroupTrack groupAtk = asset.CreateTrack<GroupTrack>(null, AtkStrTag);
        AnimationTrack attacker = asset.CreateTrack<AnimationTrack>(groupAtk, "attacker");
        
        GroupTrack groupDef = asset.CreateTrack<GroupTrack>(null, DefStrTag);
        AnimationTrack enemy = asset.CreateTrack<AnimationTrack>(groupDef, "enemy");
        PlayableTrack dmg = asset.CreateTrack<PlayableTrack>(groupDef, "dmg");
        AssetDatabase.SaveAssets();
    }
    private static void DoCreateSkillGameObject(string skillName,string localPath) 
    {
        GameObject skillRoot = new GameObject(skillName);
        PlayableDirector playableDirector = skillRoot.AddComponent<PlayableDirector>();
        playableDirector.playableAsset = AssetDatabase.LoadAssetAtPath<PlayableAsset>(GetTimelineLocalPath(skillName));
        GameObject atkRoot = new GameObject("atkRoot");
        GameObject targetRoot = new GameObject("targetRoot");
        GameObject atkEffectRoot = new GameObject("atkEffectRoot");
        GameObject targetEffectRoot = new GameObject("targetEffectRoot");
        atkRoot.transform.SetParent(skillRoot.transform);
        targetRoot.transform.SetParent(skillRoot.transform);
        atkEffectRoot.transform.SetParent(skillRoot.transform);
        targetEffectRoot.transform.SetParent(skillRoot.transform);

        PrefabUtility.SaveAsPrefabAssetAndConnect(skillRoot, localPath, InteractionMode.UserAction);
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = skillRoot;
        TimelineAsset timelineAsset = new TimelineAsset();
    }

    public static void CraeteSkillGameObject(int skillId) 
    {
        string skillName = GetSkillName(skillId);
        string localPath = GetSkillLocalPath(skillName);
        if (File.Exists(localPath))
        {
            if (EditorUtility.DisplayDialog("提示", "技能prefab已经存在是否覆盖", "覆盖"))
            {
                DoCreateTimeLine(skillName);
                DoCreateSkillGameObject(skillName, localPath);
            }
        }
        else 
        {
            DoCreateTimeLine(skillName);
            DoCreateSkillGameObject(skillName, localPath);
        }
    }
    [MenuItem("GameTools/测试")]
    public static void Test() 
    {
        string[] strArr = Directory.GetFiles("Assets/Resources/", "(*.asset)");
        Debug.Log(strArr.Length);
    }

    [MenuItem("GameTools/导出技能")]
    public static void ExportToConfig()
    {
        C_SkillConfig c_SkillConfig = ScriptableObject.CreateInstance<C_SkillConfig>();
        TimelineAsset timelineAsset = TimelineEditor.inspectedAsset;
        if (timelineAsset == null)
        {
            EditorUtility.DisplayDialog("错误", "请选中要导出的技能", "确认");
            return;
        }
        if (TryGetSkillIdByTimelineName(timelineAsset.name, out int tempId))
            c_SkillConfig.SkillId = tempId;
        else
        {
            EditorUtility.DisplayDialog("错误", "TimeLine 命名错误", "确认");
            return;
        }
        List<Config_ActionCommon> casterList = new List<Config_ActionCommon>();
        List<Config_ActionCommon> targetList = new List<Config_ActionCommon>();
        c_SkillConfig.CasterList = casterList;
        c_SkillConfig.TargetList = targetList;
        

        foreach (var trackAsset in timelineAsset.GetRootTracks())
        {
            if (trackAsset is GroupTrack)
            {
                if (AtkStrTag.Equals(trackAsset.name))
                {
                    casterList.AddRange(ParseGroupAsset((GroupTrack)trackAsset));
                }
                else if (DefStrTag.Equals(trackAsset.name))
                {
                    targetList.AddRange(ParseGroupAsset((GroupTrack)trackAsset));
                }
                else 
                {
                    Debug.LogError($"group命名错误？trackAsset.name:   {trackAsset.name}");
                }
            }
            else if (!MarkersTrackName.Equals(trackAsset.name))
            {
                Debug.LogError($"没分组的是什么？trackAsset.name:   {trackAsset.name}");
            }
        }

        AssetDatabase.CreateAsset(c_SkillConfig, $"Assets/Resources/skill{c_SkillConfig.SkillId}.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = c_SkillConfig;

        Debug.Log("导出");
    }

    private static List<Config_ActionCommon> ParseGroupAsset(GroupTrack groupTrack)
    {
        List<Config_ActionCommon> list = new List<Config_ActionCommon>();
        foreach (TrackAsset childTrack in groupTrack.GetChildTracks())
        {
            if (childTrack is AnimationTrack)
                list.AddRange(ParseAsset((AnimationTrack)childTrack));
            else if (childTrack is ActivationTrack)
                list.AddRange(ParseAsset((ActivationTrack)childTrack));
            else if (childTrack is PlayableTrack)
                list.AddRange(ParseAsset((PlayableTrack)childTrack));
            else if (childTrack is AudioTrack)
                list.AddRange(ParseAsset((AudioTrack)childTrack));
        }
        return list;
    }

    private static List<Config_ActionCommon> ParseAsset(AnimationTrack animationTrack)
    {
        List<Config_ActionCommon> list = new List<Config_ActionCommon>();
        Config_ActionAnim config_ActionAnim;
        foreach (TimelineClip clip in animationTrack.GetClips())
        {
            config_ActionAnim = new Config_ActionAnim();
            config_ActionAnim.StartFrame = ParseToFrame(clip.start);
            config_ActionAnim.Duration = ParseToFrame(clip.duration);
            config_ActionAnim.AnimName = clip.animationClip.name;
            list.Add(new Config_ActionCommon(config_ActionAnim));
        }
        return list;
    }

    private static List<Config_ActionCommon> ParseAsset(ActivationTrack activationTrack)
    {
        List<Config_ActionCommon> list = new List<Config_ActionCommon>();
        Config_ActionArt config_ActionArt;
        foreach (TimelineClip clip in activationTrack.GetClips())
        {
            config_ActionArt = new Config_ActionArt();
            config_ActionArt.StartFrame = ParseToFrame(clip.start);
            config_ActionArt.Duration = ParseToFrame(clip.duration);
            config_ActionArt.ArtName = activationTrack.name;
            list.Add(new Config_ActionCommon(config_ActionArt));
        }
        return list;
    }

    private static List<Config_ActionCommon> ParseAsset(AudioTrack audioTrack)
    {
        List<Config_ActionCommon> list = new List<Config_ActionCommon>();
        Config_ActionSound config_ActionSound;
        foreach (TimelineClip clip in audioTrack.GetClips())
        {
            config_ActionSound = new Config_ActionSound();
            config_ActionSound.StartFrame = ParseToFrame(clip.start);
            config_ActionSound.SoundName = audioTrack.name;
            list.Add(new Config_ActionCommon(config_ActionSound));
        }
        return list;
    }

    private static List<Config_ActionCommon> ParseAsset(PlayableTrack playableTrack)
    {
        List<Config_ActionCommon> list = new List<Config_ActionCommon>();
        foreach (TimelineClip clip in playableTrack.GetClips())
        {
            if (clip.asset is SkillDamagePlayable)
            {
                SkillDamagePlayable dmgPlayable = (SkillDamagePlayable)clip.asset;
                Config_ActionDamage actionDmg = new Config_ActionDamage();
                actionDmg.StartFrame = ParseToFrame(clip.start);
                actionDmg.DamageType = dmgPlayable.DamageType;
                list.Add(new Config_ActionCommon(actionDmg));
            }
            else if (clip.asset is SkillMovePlayable)
            {
                SkillMovePlayable movePlayable = (SkillMovePlayable)clip.asset;
                Config_ActionMove actionMove = new Config_ActionMove();
                actionMove.StartFrame = ParseToFrame(clip.start);
                actionMove.Duration = ParseToFrame(clip.duration);
                actionMove.MoveType = movePlayable.MoveType;
                actionMove.MoveTargetType = movePlayable.MoveTargetType;
                list.Add(new Config_ActionCommon(actionMove));
            }
            else
            {
                Debug.LogError($"这个类型没做代码支持 clip.asset.name:   {clip.asset.name}");
            }
        }
        return list;
    }


}
