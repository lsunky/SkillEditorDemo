using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightRender : MonoBehaviour
{
    public static List<string> listAnimNames = new List<string>() 
    { 
        "Die", 
        "Idle_GunMiddle",
        "Idle_Shoot",
        "Run_Guard", 
        "Shoot_Auto", 
        "Shoot_single", 
        "WalkBack_Shoot", 
        "WalkForward_Shoot",
        "WalkLeft_Shoot",
        "WalkRight_Shoot"
    };

    public GameObject goA;
    public GameObject goB;

    private List<SimpleAnimation> roleList;
    

    private void Awake()
    {
        Dictionary<string, AnimationClip> dicAnim = new Dictionary<string, AnimationClip>(); ;
        foreach (var item in listAnimNames)
        {
            dicAnim[item] = Resources.Load<AnimationClip>($"Animations/{item}");
        }
        roleList = new List<SimpleAnimation>();
        roleList.Add(goA.AddComponent<SimpleAnimation>());
        roleList.Add(goB.AddComponent<SimpleAnimation>());

        foreach (var item in roleList)
        {
            foreach (var animInfo in dicAnim)
            {
                item.AddClip(animInfo.Value,animInfo.Key);
            }

            item.Play("Idle_GunMiddle");
        }
        
    }
    public void PlayAnim(int roleUid,string animName) 
    {
        roleList[roleUid-1].Play(animName);
    }

    public void CreateArt(string artEffectName) 
    {
        GameObject effect = Resources.Load<GameObject>(artEffectName);
        GameObject.Instantiate(effect);
    }
}
