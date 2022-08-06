using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[UnityEditor.CustomEditor(typeof(WeaponsScriptableObject))]
public class WeaponsScriptableObjectEditor : UnityEditor.Editor
{
    // List<System.Type> types;
    public WeaponsScriptableObjectEditor()
    {
        // types = System.Reflection.Assembly.GetAssembly(typeof(WeaponInfo)).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(WeaponInfo))).ToList();
    }
    public override void OnInspectorGUI()
    {
        var script = (WeaponsScriptableObject)target;

        // foreach (var t in types)
        // {
            // string[] typeNames = t.ToString().Split('+');
            // if (GUILayout.Button($"Add {typeNames[typeNames.Length - 1]}", GUILayout.Height(40)))
            // {
            //     WeaponInfo Weapon = System.Activator.CreateInstance(t) as WeaponInfo;
            //     Weapon.Id = script.Objects.Count;
            //     script.Objects.Add(Weapon);
            // }
        // }
            if (GUILayout.Button($"Add WeaponInfo", GUILayout.Height(40)))
            {
                WeaponInfo Weapon = new WeaponInfo();
                Weapon.Id = script.Objects.Count;
                script.Objects.Add(Weapon);
            }

        base.OnInspectorGUI();
    }
}