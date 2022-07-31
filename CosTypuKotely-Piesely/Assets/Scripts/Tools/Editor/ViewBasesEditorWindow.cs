using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;

public class ViewBasesEditorWindow
{
    Vector2 scrollPos;
    private Dictionary<Type, Action<object>> fieldsDictionary = new Dictionary<Type, Action<object>>();

    List<BaseInfo> filterList = new List<BaseInfo>();
    DataBasesEditorWindow DataEditor { get; set; }
    public void Init(DataBasesEditorWindow x)
    {
        DataEditor = x;
        FillDictionary();
        RefreshLists();
    }

    public void FillDictionary()
    {
        fieldsDictionary.Add(typeof(int), (obj) =>
        {
            int x = (int)obj;
            GUILayout.Label(x.ToString());
        });

        fieldsDictionary.Add(typeof(float), (obj) =>
        {
            float x = (float)obj;
            GUILayout.Label(x.ToString());
        });

        fieldsDictionary.Add(typeof(double), (obj) =>
        {
            double x = (double)obj;
            GUILayout.Label(x.ToString());
        });

        fieldsDictionary.Add(typeof(Sprite), (obj) =>
        {
            Sprite x = (Sprite)obj;
            GUILayout.Box(Utils.GenerateTextureFromSprite(x), GUILayout.Width(100), GUILayout.Height(50));
        });

        fieldsDictionary.Add(typeof(string), (obj) =>
        {
            GUILayout.Label((string)obj);
        });
    }

    public void RefreshLists()
    {
        BaseTypeFilter(DataEditor.FilterType);
        DataEditor.SortBases(DataEditor.SortedMethod);
    }

    public void SearchBases()
    {
        DataEditor.Bases.Clear();
        if (string.IsNullOrEmpty(DataEditor.SearchString) == false)
        {
            DataEditor.Bases.AddRange(filterList.FindAll((x) => x.Name.Contains(DataEditor.SearchString)));
        }
        else
        {
            DataEditor.Bases.AddRange(filterList);
        }
    }

    public void ShowSortingButtons()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Sort By: ");
        if (GUILayout.Button("ID"))
        {
            DataEditor.SortBases(Comparer<BaseInfo>.Create((x, y) => x.Id.CompareTo(y.Id)));
        }
        if (GUILayout.Button("NAME"))
        {
            DataEditor.SortBases(Comparer<BaseInfo>.Create((x, y) => x.Name.CompareTo(y.Name)));
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

    public void ShowData(List<BaseInfo> infos)
    {
        if (infos != null)
        {
            GUILayout.BeginArea(new Rect(0, DataEditor.BeginAreaY, Screen.width - DataEditor.CreateWidth, Screen.height - 25 - DataEditor.BeginAreaY));
            scrollPos = GUILayout.BeginScrollView(scrollPos, false, true);

            int w = 0;
            int h = 0;
            float expand = DataEditor.IsShowAllFields == true ? 1.2f : 1.0f;

            foreach (var info in infos)
            {
                if (w == 0)
                {
                    GUILayout.BeginHorizontal();
                }
                GUILayout.BeginVertical();
                GUILayout.BeginArea(new Rect(100 * w, 150 * expand * h, 100, 500));
                if (DataEditor.IsShowAllFields == true)
                {
                    ShowAllInfo(info);
                }
                else
                    ShowBaseInfo(info);

                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Del"))
                {
                    DataEditor.RemoveInstance(info);
                    break;
                }
                if (GUILayout.Button("Mod"))
                {
                    DataEditor.ChangeState(DataBasesEditorWindow.State.MODIFY);

                    BaseInfo baseInfoCopy = (BaseInfo)System.Activator.CreateInstance(info.GetType(), info);
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
    }

    private void ShowAllInfo(object info)
    {
        PropertyInfo[] propertyInfos = info.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (var propertyInfo in propertyInfos)
        {
            Type t = propertyInfo.PropertyType;

            // if (t.IsGenericType == true)
            // {
            //     t = typeof(IList);
            // }

            object value = propertyInfo.GetValue(info, null);
            EditorGUILayout.LabelField($"{propertyInfo.Name}:");

            bool v = fieldsDictionary.TryGetValue(t, out Action<object> f);

            if (v == false)
            {
                EditorGUILayout.LabelField($"{t} handle not exist");
                continue;
            }

            f(value);
        }
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
