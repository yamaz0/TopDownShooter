#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Linq;

public class WeaponsEditorWindow : BasesEditorWindow
{
    public void Init()
    {
        DataEditor = DataWeaponsEditorWindow.instance;
        DataWeaponsEditorWindow.instance.Init();
        DataEditor.BaseInfoTypes = Assembly.GetAssembly(typeof(WeaponInfo)).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(WeaponInfo))).ToList();

        createBasesEditorWindow.Init(DataEditor);
        viewBasesEditorWindow.Init(DataEditor);
        // BasesScriptableObject.Instance.OnChangedBases += viewBasesEditorWindow.RefreshLists;
    }

    [MenuItem("Editors/WeaponsEditor")]
    private static void ShowWindow()
    {
        WeaponsEditorWindow window = GetWindow<WeaponsEditorWindow>();
        window.titleContent = new GUIContent("WeaponsEditor");
        window.Init();
        window.Show();
    }
}
#endif