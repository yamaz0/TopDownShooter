#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;
using System.Linq;

public class BasesEditorWindow : EditorWindow
{
    CreateBasesEditorWindow createBasesEditorWindow = new CreateBasesEditorWindow();
    ViewBasesEditorWindow viewBasesEditorWindow = new ViewBasesEditorWindow();
    private void OnEnable()
    {
        viewBasesEditorWindow.Init();
        BasesScriptableObject.Instance.OnChangedBases += viewBasesEditorWindow.RefreshLists;
        DataBasesEditorWindow.instance.BaseInfoTypes = Assembly.GetAssembly(typeof(BaseInfo)).GetTypes().Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(BaseInfo))).ToList();
    }

    private void OnDisable()
    {
        BasesScriptableObject.Instance.OnChangedBases -= viewBasesEditorWindow.RefreshLists;
    }

    [MenuBase("ProjektMagic/BasesEditor")]
    private static void ShowWindow()
    {
        BasesEditorWindow window = GetWindow<BasesEditorWindow>();
        window.titleContent = new GUIContent("BasesEditor");
        window.Show();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("clear"))
        {
            // BasesScriptableObject.Instance.Bases.ForEach(x => DestroyImmediate(x, true));
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            BasesScriptableObject.Instance.Bases.Clear();
            Debug.Log(BasesScriptableObject.Instance.Bases.Count);
        }

        if (GUILayout.Button("Create"))
        {
            DataBasesEditorWindow.instance.ChangeState(DataBasesEditorWindow.State.CREATE);
            DataBasesEditorWindow.instance.ResetSelectedBase();
        }

        viewBasesEditorWindow.ShowSearch();

        if (GUILayout.Button("Show/Hide filtres"))
        {
            DataBasesEditorWindow.instance.ShowHideBaseFilter();
        }
        if (DataBasesEditorWindow.instance.IsShowFilter == true)
        {
            createBasesEditorWindow.ShowBasesTypesButtons(viewBasesEditorWindow.BaseTypeFilter);
            if (GUILayout.Button("ALL"))
            {
                viewBasesEditorWindow.BaseTypeFilter(null);
            }
            viewBasesEditorWindow.ShowChangeSortOrder();

            viewBasesEditorWindow.ShowSortingButtons();
        }

        EditorGUIUtility.labelWidth = 80;

        GUILayout.BeginArea(new Rect(Screen.width - DataBasesEditorWindow.instance.CreateWidth, DataBasesEditorWindow.instance.BeginAreaY, DataBasesEditorWindow.instance.CreateWidth, Screen.height));
        switch (DataBasesEditorWindow.instance.CurrentState)
        {
            case DataBasesEditorWindow.State.NONE:
                break;
            case DataBasesEditorWindow.State.CREATE:
                createBasesEditorWindow.ShowCreateBases();
                break;
            case DataBasesEditorWindow.State.MODIFY:
                createBasesEditorWindow.Modify();
                break;
            default:
                break;
        }
        GUILayout.EndArea();

        viewBasesEditorWindow.ShowBases(DataBasesEditorWindow.instance.Bases);

        if (GUI.Button(new Rect(0, 0, Screen.width, Screen.height), "", GUIStyle.none))
        {
            GUI.FocusControl(null);
        }
    }


    public static string TextField(string label, string text)
    {
        var textDimensions = GUI.skin.label.CalcSize(new GUIContent(label));
        EditorGUIUtility.labelWidth = textDimensions.x;
        return EditorGUILayout.TextField(label, text);
    }
}
#endif