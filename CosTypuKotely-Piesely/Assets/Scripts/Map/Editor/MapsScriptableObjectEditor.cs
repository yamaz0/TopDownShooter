using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[UnityEditor.CustomEditor(typeof(MapsScriptableObject))]
public class MapsScriptableObjectEditor : UnityEditor.Editor
{
    // List<System.Type> types;
    public MapsScriptableObjectEditor()
    {
        // types = System.Reflection.Assembly.GetAssembly(typeof(MapInfo)).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(MapInfo))).ToList();
    }
    public override void OnInspectorGUI()
    {
        var script = (MapsScriptableObject)target;

        // foreach (var t in types)
        // {
            // string[] typeNames = t.ToString().Split('+');
            // if (GUILayout.Button($"Add {typeNames[typeNames.Length - 1]}", GUILayout.Height(40)))
            // {
            //     MapInfo Map = System.Activator.CreateInstance(t) as MapInfo;
            //     Map.Id = script.Objects.Count;
            //     script.Objects.Add(Map);
            // }
        // }
            if (GUILayout.Button($"Add MapInfo", GUILayout.Height(40)))
            {
                MapInfo Map = new MapInfo();
                Map.Id = script.Objects.Count;
                script.Objects.Add(Map);
            }

        base.OnInspectorGUI();
    }
}
