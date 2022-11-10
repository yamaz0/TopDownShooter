using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[UnityEditor.CustomEditor(typeof(EnemiesScriptableObject))]
public class EnemiesScriptableObjectEditor : UnityEditor.Editor
{
    // List<System.Type> types;
    public EnemiesScriptableObjectEditor()
    {
        // types = System.Reflection.Assembly.GetAssembly(typeof(EnemyInfo)).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(EnemyInfo))).ToList();
    }
    public override void OnInspectorGUI()
    {
        var script = (EnemiesScriptableObject)target;

        // foreach (var t in types)
        // {
            // string[] typeNames = t.ToString().Split('+');
            // if (GUILayout.Button($"Add {typeNames[typeNames.Length - 1]}", GUILayout.Height(40)))
            // {
            //     EnemyInfo Enemy = System.Activator.CreateInstance(t) as EnemyInfo;
            //     Enemy.Id = script.Objects.Count;
            //     script.Objects.Add(Enemy);
            // }
        // }
            if (GUILayout.Button($"Add EnemyInfo", GUILayout.Height(40)))
            {
                EnemyInfo Enemy = new EnemyInfo();
                Enemy.Id = script.Objects.Count;
                script.Objects.Add(Enemy);
            }

        base.OnInspectorGUI();
    }
}
