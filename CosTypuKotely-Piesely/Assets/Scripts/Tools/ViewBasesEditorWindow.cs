using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ViewBasesEditorWindow
{
    Vector2 scrollPos;

    List<BaseInfo> filterList = new List<BaseInfo>();

    public void Init()
    {
        RefreshLists();
    }

    public void RefreshLists()
    {
        BaseTypeFilter(DataBasesEditorWindow.instance.FilterType);
        DataBasesEditorWindow.instance.SortBases(DataBasesEditorWindow.instance.SortedMethod);
    }

    public void SearchBases()
    {
        DataBasesEditorWindow.instance.Bases.Clear();
        if (string.IsNullOrEmpty(DataBasesEditorWindow.instance.SearchString) == false)
        {
            DataBasesEditorWindow.instance.Bases.AddRange(filterList.FindAll((x) => x.Name.Contains(DataBasesEditorWindow.instance.SearchString)));
        }
        else
        {
            DataBasesEditorWindow.instance.Bases.AddRange(filterList);
        }
    }

    public void ShowSortingButtons()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Sort By: ");
        if (GUILayout.Button("ID"))
        {
            DataBasesEditorWindow.instance.SortBases(Comparer<BaseInfo>.Create((x, y) => x.Id.CompareTo(y.Id)));
        }
        if (GUILayout.Button("NAME"))
        {
            DataBasesEditorWindow.instance.SortBases(Comparer<BaseInfo>.Create((x, y) => x.Name.CompareTo(y.Name)));
        }
//TODO wiecej compererow jakos zrobic dynamicznie ze wzgledu na typ
        GUILayout.EndHorizontal();
    }

    public void ShowChangeSortOrder()
    {
        if (GUILayout.Button("Change order"))
        {
            DataBasesEditorWindow.instance.IsSortDescending = !DataBasesEditorWindow.instance.IsSortDescending;
            DataBasesEditorWindow.instance.ReverseBaseList();
        }
    }

    public void ShowBases(List<BaseInfo> infos)
    {
        if (infos != null)
        {
            GUILayout.BeginArea(new Rect(0, DataBasesEditorWindow.instance.BeginAreaY, Screen.width - DataBasesEditorWindow.instance.CreateWidth, Screen.height - 25 - DataBasesEditorWindow.instance.BeginAreaY));
            scrollPos = GUILayout.BeginScrollView(scrollPos,false,true);

            int w = 0;
            int h = 0;
            float expand = DataBasesEditorWindow.instance.IsShowAllFields == true ? 1.2f : 1.0f;

            foreach (var info in infos)
            {
                if(w == 0)
                {
                    GUILayout.BeginHorizontal();
                }
                        GUILayout.BeginVertical();
                            GUILayout.BeginArea(new Rect(100*w, 150*expand*h, 100, 150));
                            if(DataBasesEditorWindow.instance.IsShowAllFields == true)
                            {
                                info.ShowAllBaseInfo();
                            }
                            else
                                info.ShowBaseBaseInfo();

                                    GUILayout.BeginHorizontal();
                                    if(GUILayout.Button("Del"))
                                    {
                                        DataBasesEditorWindow.instance.RemoveBase(info);
                                        break;
                                    }
                                    if (GUILayout.Button("Mod"))
                                    {
                                        DataBasesEditorWindow.instance.ChangeState(DataBasesEditorWindow.State.MODIFY);

                                        BaseInfo baseInfoCopy = (BaseInfo)System.Activator.CreateInstance(info.GetType());
                                        baseInfoCopy.CopyValues(info);

                                        DataBasesEditorWindow.instance.SetCurrentSelectBase(baseInfoCopy);
                                    }
                                    GUILayout.EndHorizontal();
                            GUILayout.EndArea();
                            GUILayout.Space(150);
                        GUILayout.EndVertical();

                    w++;
                    if(w > (Screen.width-DataBasesEditorWindow.instance.CreateWidth-10)/100-1)
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
        DataBasesEditorWindow.instance.SearchStringField = EditorGUILayout.TextField(DataBasesEditorWindow.instance.SearchStringField);
        if (GUILayout.Button("Search"))
        {
            DataBasesEditorWindow.instance.SearchString = DataBasesEditorWindow.instance.SearchStringField;
            SearchBases();
        }
    }

    public void BaseTypeFilter(System.Type t)
    {
        DataBasesEditorWindow.instance.FilterType = t;
        filterList.Clear();

        if(t == null)
        {
            filterList.AddRange(BasesScriptableObject.Instance.Bases);
            DataBasesEditorWindow.instance.IsShowAllFields = false;
        }
        else
        {
            filterList.AddRange(BasesScriptableObject.Instance.Bases.FindAll((x) => x.GetType().Equals(t)));
            DataBasesEditorWindow.instance.IsShowAllFields = true;
        }

        SearchBases();
    }

}
