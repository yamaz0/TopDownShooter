using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[UnityEditor.CustomEditor(typeof(StructureScriptableObject))]
public class StructureScriptableObjectEditor : UnityEditor.Editor
{
    List<System.Type> types;
    public StructureScriptableObjectEditor()
    {
        types = System.Reflection.Assembly.GetAssembly(typeof(StructureInfo)).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(StructureInfo))).ToList();
    }
    public override void OnInspectorGUI()
    {
        var script = (StructureScriptableObject)target;

        foreach (var t in types)
        {
            string[] typeNames = t.ToString().Split('+');
            if (GUILayout.Button($"Add {typeNames[typeNames.Length - 1]}", GUILayout.Height(40)))
            {
                StructureInfo Structure = System.Activator.CreateInstance(t) as StructureInfo;
                Structure.Id = script.Objects.Count;
                script.Objects.Add(Structure);
            }
        }

        base.OnInspectorGUI();
    }
}