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
    protected CreateBasesEditorWindow createBasesEditorWindow = new CreateBasesEditorWindow();
    protected ViewBasesEditorWindow viewBasesEditorWindow = new ViewBasesEditorWindow();

    public DataBasesEditorWindow DataEditor { get; set; }

    private void OnDisable()
    {
        // BasesScriptableObject.Instance.OnChangedBases -= viewBasesEditorWindow.RefreshLists;
    }

    private void OnGUI()
    {
        // if (GUILayout.Button("clear"))
        // {
        //     // BasesScriptableObject.Instance.Bases.ForEach(x => DestroyImmediate(x, true));
        //     AssetDatabase.SaveAssets();
        //     AssetDatabase.Refresh();
        //     BasesScriptableObject.Instance.Bases.Clear();
        //     Debug.Log(BasesScriptableObject.Instance.Bases.Count);
        // }

        if (GUILayout.Button("Create"))
        {
            DataEditor.ChangeState(DataBasesEditorWindow.State.CREATE);
            DataEditor.ResetSelectedBase();
        }

        viewBasesEditorWindow.ShowSearch();

        if (GUILayout.Button("Show/Hide filtres"))
        {
            DataEditor.ShowHideBaseFilter();
        }
        if (DataEditor.IsShowFilter == true)
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

        GUILayout.BeginArea(new Rect(Screen.width - DataEditor.CreateWidth, DataEditor.BeginAreaY, DataEditor.CreateWidth, Screen.height));
        switch (DataEditor.CurrentState)
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

        viewBasesEditorWindow.ShowData(DataEditor.Data);

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