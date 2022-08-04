using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;

public class ViewBasesEditorWindow
{
    Vector2 scrollPos;

    List<BaseInfo> filterList = new List<BaseInfo>();
    DataBasesEditorWindow DataEditor { get; set; }
    public void Init(DataBasesEditorWindow x)
    {
        DataEditor = x;
        DataEditor.Data.Init();
        DataEditor.OnDataChanged += RefreshLists;

        RefreshLists();
    }

    public void RefreshLists()
    {
        BaseTypeFilter(DataEditor.FilterType);
        DataEditor.SortBases(DataEditor.SortedMethod);
    }

    public void SearchBases()
    {
        DataEditor.Data.TileInfos.Clear();
        if (string.IsNullOrEmpty(DataEditor.SearchString) == false)
        {
            // DataEditor.Bases.AddRange(filterList.FindAll((x) => x.Name.Contains(DataEditor.SearchString)));
            DataEditor.Data.Add(filterList.FindAll((x) => x.Name.Contains(DataEditor.SearchString)));
        }
        else
        {
            DataEditor.Data.Add(filterList);
        }
    }

    public void ShowSortingButtons()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Sort By: ");
        if (GUILayout.Button("ID"))
        {
            DataEditor.SortBases(Comparer<TileInfo>.Create((x, y) => x.BaseInfoCache.Id.CompareTo(y.BaseInfoCache.Id)));
        }
        if (GUILayout.Button("NAME"))
        {
            DataEditor.SortBases(Comparer<TileInfo>.Create((x, y) => x.BaseInfoCache.Name.CompareTo(y.BaseInfoCache.Name)));
        }
        //TODO wiecej compererow jakos zrobic dynamicznie ze wzgledu na typ
        GUILayout.EndHorizontal();
    }

    public void ShowChangeSortOrder()
    {
        if (GUILayout.Button("Change order"))
        {
            DataEditor.IsSortDescending = !DataEditor.IsSortDescending;
            DataEditor.ReverseBaseList();
        }
    }

    public void ShowData(Data data)
    {
        // System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();
        // s.Start();
        if (data != null)
        {
            GUILayout.BeginArea(new Rect(0, DataEditor.BeginAreaY, Screen.width - DataEditor.CreateWidth, Screen.height - 25 - DataEditor.BeginAreaY));
            scrollPos = GUILayout.BeginScrollView(scrollPos, false, true);

            int w = 0;
            int h = 0;
            float expand = DataEditor.IsShowAllFields == true ? DataEditor.Data.MaxFieldsHeight : 150.0f;

            foreach (var info in data.TileInfos)
            {
                if (w == 0)
                {
                    GUILayout.BeginHorizontal();
                }
                GUILayout.BeginVertical();
                GUILayout.BeginArea(new Rect(100 * w, expand * h, 100, 500));
                if (DataEditor.IsShowAllFields == true)
                {
                    ShowAllInfo(info);
                }
                else
                    ShowBaseInfo(info.BaseInfoCache);

                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Del"))
                {
                    DataEditor.RemoveInstance(info.BaseInfoCache);
                    break;
                }
                if (GUILayout.Button("Mod"))
                {
                    DataEditor.ChangeState(DataBasesEditorWindow.State.MODIFY);

                    BaseInfo baseInfoCopy = (BaseInfo)System.Activator.CreateInstance(info.BaseInfoCache.GetType(), info.BaseInfoCache);
                    // baseInfoCopy.CopyValues(info);

                    DataEditor.SetCurrentSelectBase(baseInfoCopy);
                }
                GUILayout.EndHorizontal();
                GUILayout.EndArea();
                GUILayout.Space(150);
                GUILayout.EndVertical();

                w++;
                if (w > (Screen.width - DataEditor.CreateWidth - 10) / 100 - 1)
                {
                    w = 0;
                    h++;
                    GUILayout.EndHorizontal();
                }
            };

            GUILayout.EndScrollView();
            GUILayout.EndArea();
        }
        // s.Stop();
        // Debug.Log(s.Elapsed);
    }

    private void ShowAllInfo(TileInfo info)
    {
        foreach (var field in info.Fields)
        {
            field.Show();
        }
        // PropertyInfo[] propertyInfos = info.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        // foreach (var propertyInfo in propertyInfos)
        // {
        //     Type t = propertyInfo.PropertyType;

        //     // if (t.IsGenericType == true)
        //     // {
        //     //     t = typeof(IList);
        //     // }

        //     object value = propertyInfo.GetValue(info, null);
        //     EditorGUILayout.LabelField($"{propertyInfo.Name}:");

        //     bool v = fieldsDictionary.TryGetValue(t, out Action<object> f);

        //     if (v == false)
        //     {
        //         EditorGUILayout.LabelField($"{t} handle not exist");
        //         continue;
        //     }

        //     f(value);
        // }
    }

    private void ShowBaseInfo(BaseInfo info)
    {
        GUILayout.Label("Id: " + info.Id.ToString());
        GUILayout.Label(info.Name);
    }

    public void ShowSearch()
    {
        DataEditor.SearchStringField = EditorGUILayout.TextField(DataEditor.SearchStringField);
        if (GUILayout.Button("Search"))
        {
            DataEditor.SearchString = DataEditor.SearchStringField;
            SearchBases();
        }
    }

    public void BaseTypeFilter(System.Type t)
    {
        DataEditor.FilterType = t;
        filterList.Clear();

        if (t == null)
        {
            filterList.AddRange(DataEditor.DataInstance.Objects);
            DataEditor.IsShowAllFields = false;
        }
        else
        {
            filterList.AddRange(DataEditor.DataInstance.Objects.FindAll((x) => x.GetType().Equals(t)));
            DataEditor.IsShowAllFields = true;
        }

        SearchBases();
    }

}
