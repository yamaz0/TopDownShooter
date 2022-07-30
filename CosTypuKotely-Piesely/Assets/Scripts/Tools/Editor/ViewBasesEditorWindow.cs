using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ViewBasesEditorWindow
{
    Vector2 scrollPos;

    List<BaseInfo> filterList = new List<BaseInfo>();
    DataBasesEditorWindow DataEditor { get; set; }

    public void Init(DataBasesEditorWindow x)
    {
        DataEditor = x;
        RefreshLists();
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

    public void ShowBases(List<BaseInfo> infos)
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
                GUILayout.BeginArea(new Rect(100 * w, 150 * expand * h, 100, 150));
                if (DataEditor.IsShowAllFields == true)
                {
                    info.ShowAllBaseInfo();
                }
                else
                    info.ShowBaseBaseInfo();

                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Del"))
                {
                    DataEditor.RemoveInstance(info);
                    break;
                }
                if (GUILayout.Button("Mod"))
                {
                    DataEditor.ChangeState(DataBasesEditorWindow.State.MODIFY);

                    BaseInfo baseInfoCopy = (BaseInfo)System.Activator.CreateInstance(info.GetType(),info);
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
