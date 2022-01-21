
using UnityEditor;
using UnityEngine;

public class SkillCreateWindow : EditorWindow
{
    static SkillCreateWindow window;
    private string skillId;
    [MenuItem("GameTools/创建技能")]
    private static void Init() 
    {
        window = GetWindow<SkillCreateWindow>("技能编辑器");
        window.position = new Rect(200, 300, 600, 400);
        window.maxSize = new Vector2(600, 400);
        window.Show();
    }

    private void OnGUI()
    {
        skillId = EditorGUILayout.TextField("请输入技能id:", skillId);
       
        if (GUILayout.Button("创建"))
        {
            if (int.TryParse(skillId, out int a))
            {
                SkillConfigTool.CraeteSkillGameObject(a);
                window.Close();
            }
            else 
            {
                EditorUtility.DisplayDialog("错误","技能id错误，请输入整形","确认");
            }
        }

    }
}
