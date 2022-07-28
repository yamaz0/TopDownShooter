using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;
using System.Linq;

public class CreateBasesEditorWindow
{
    public void ShowBackButton()
    {
        if (GUILayout.Button("X",GUILayout.Width(50)))
        {
            DataBasesEditorWindow.instance.ChangeState(DataBasesEditorWindow.State.NONE);
        }
    }

    public void ShowCreateBases()
    {
        ShowBackButton();

        if(DataBasesEditorWindow.instance.CurrentBase == null)
        {
            ShowBasesTypesButtons(DataBasesEditorWindow.instance.CreateBaseTypeInstance);
        }
        else
        {
            if (GUILayout.Button("Select other type"))
            {
                DataBasesEditorWindow.instance.ResetSelectedBase();
                return;
            }

            DataBasesEditorWindow.instance.CurrentBase.ShowFields();

            if (GUILayout.Button("ADD"))
            {
                BasesScriptableObject.Instance.AddBase(DataBasesEditorWindow.instance.CurrentBase);
                DataBasesEditorWindow.instance.ResetSelectedBase();
            }
        }
        // createBasesEditorWindow.ShowBasesCreator();
    }

    public void ShowBasesTypesButtons(Action<Type> OnButtonTypeClicked)
    {
        GUILayout.Label("Bases Types");
        GUILayout.BeginHorizontal();
        foreach (var t in DataBasesEditorWindow.instance.BaseInfoTypes)
        {
            if (GUILayout.Button(t.ToString()))
            {
                OnButtonTypeClicked(t);
            }
        }
        GUILayout.EndHorizontal();
    }

    public void Modify()
    {
        ShowBackButton();

        DataBasesEditorWindow.instance.CurrentBase.ShowFields();

        if (GUILayout.Button("Save"))
        {
            DataBasesEditorWindow.instance.SaveBaseInstance();
        }
    }
}
