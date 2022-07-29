using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;
using System.Linq;

public class CreateBasesEditorWindow
{
    private Dictionary<Type, Func<object, object>> fieldsDictionary = new Dictionary<Type, Func<object, object>>();
    DataBasesEditorWindow DataEditor { get; set; }

    public void Init(DataBasesEditorWindow dataEditor)
    {
        DataEditor = dataEditor;
        FillDictionary();
    }

    public void FillDictionary()
    {
        fieldsDictionary.Add(typeof(int), (obj) =>
        {
            return EditorGUILayout.IntField("int: ", (int)obj);
        });

        fieldsDictionary.Add(typeof(float), (obj) =>
        {
            return EditorGUILayout.FloatField("float: ", (float)obj);
        });

        fieldsDictionary.Add(typeof(string), (obj) =>
        {
            return EditorGUILayout.TextField("string: ", (string)obj);
        });

        fieldsDictionary.Add(typeof(Sprite), (obj) =>
        {
            return EditorGUILayout.ObjectField("Sprite: ", (Sprite)obj, typeof(Sprite), false);
        });
    }

    public void ShowBackButton()
    {
        if (GUILayout.Button("X", GUILayout.Width(50)))
        {
            DataEditor.ChangeState(DataBasesEditorWindow.State.NONE);
        }
    }

    public void ShowCreateBases()
    {
        ShowBackButton();

        if (DataEditor.CurrentObjectInstance == null)
        {
            ShowBasesTypesButtons(DataEditor.CreateBaseTypeInstance);
        }
        else
        {
            if (GUILayout.Button("Select other type"))
            {
                DataEditor.ResetSelectedBase();
                return;
            }

            ShowFields(DataEditor.CurrentObjectInstance);

            if (GUILayout.Button("ADD"))
            {
                DataEditor.AddCurrentInstance();
            }
        }
        // createBasesEditorWindow.ShowBasesCreator();
    }
    public void ShowFields(BaseInfo inf)
    {

        PropertyInfo[] propertyInfos = inf.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var propertyInfo in propertyInfos)
        {
            Debug.Log(propertyInfo.Name);
            object value = propertyInfo.GetValue(inf);
            EditorGUILayout.LabelField($"{propertyInfo.Name}:");

            bool v = fieldsDictionary.TryGetValue(propertyInfo.PropertyType, out Func<object, object> f);

            if (v == false)
            {
                EditorGUILayout.LabelField($"{propertyInfo.PropertyType} handle not exist");
                continue;
            }

            value = f(value);
            propertyInfo.SetValue(inf, value);
        }
    }
    public void ShowBasesTypesButtons(Action<Type> OnButtonTypeClicked)
    {
        GUILayout.Label("Bases Types");
        GUILayout.BeginHorizontal();
        foreach (var t in DataEditor.BaseInfoTypes)
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

        ShowFields(DataEditor.CurrentObjectInstance);

        if (GUILayout.Button("Save"))
        {
            DataEditor.SaveCurrentInstance();
        }
    }
}
