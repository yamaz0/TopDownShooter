using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;


[CreateAssetMenu(fileName = "DataWeaponsEditorWindow", menuName = "ScriptableObjects/DataWeaponsEditorWindow")]
public class DataWeaponsEditorWindow : ScriptableSingleton<WeaponInfo>
{

}

[CreateAssetMenu(fileName = "DataBasesEditorWindow", menuName = "ScriptableObjects/DataBasesEditorWindow")]
public class DataBasesEditorWindow : ScriptableSingleton<DataBasesEditorWindow> where Y: BaseInfo
{
    public enum State
    {
        NONE,
        CREATE,
        MODIFY
    }

    [SerializeField]
    private int createWidth = 0;

    private bool isShowFilter = false;
    private bool isShowAllFields = false;
    private string searchString = string.Empty;
    private string searchStringField = string.Empty;
    private System.Type filterType = null;
    private Comparer<Y> sortedMethod = Comparer<Y>.Create((x, y) => x.Id.CompareTo(y.Id));
    private bool isSortDescending = false;
    private List<Y> bases = new List<Y>();

    private List<Type> baseInfoTypes;
    private State currentState = new State();
    private State previusState = new State();
    private Y currentBase = null;

    private int basesViewStartY = 110;

    public bool IsShowFilter { get => isShowFilter; set => isShowFilter = value; }
    public string SearchString { get => searchString; set => searchString = value; }
    public string SearchStringField { get => searchStringField; set => searchStringField = value; }
    public List<Y> Bases { get => bases; set => bases = value; }
    public List<Type> BaseInfoTypes { get => baseInfoTypes; set => baseInfoTypes = value; }
    public State CurrentState { get => currentState; set => currentState = value; }
    public State PreviusState { get => previusState; set => previusState = value; }
    public Y CurrentBase { get => currentBase; set => currentBase = value; }
    public int CreateWidth { get => createWidth; set => createWidth = value; }
    public int BeginAreaY { get => basesViewStartY; set => basesViewStartY = value; }
    public bool IsShowAllFields { get => isShowAllFields; set => isShowAllFields = value; }
    public Type FilterType { get => filterType; set => filterType = value; }
    public Comparer<Y> SortedMethod { get => sortedMethod; set => sortedMethod = value; }
    public bool IsSortDescending { get => isSortDescending; set => isSortDescending = value; }

    public void ChangeState(State s)
    {
        PreviusState = CurrentState;
        CurrentState = s;
        switch (CurrentState)
        {
            case State.NONE:
                CreateWidth = 0;
                break;
            case State.CREATE:
                CreateWidth = 300;
                break;
            case State.MODIFY:
                CreateWidth = 300;
                break;
            default:
                break;
        }
    }
    public void SetCurrentSelectBase(Y info)
    {
        CurrentBase = info;
    }

    public void ResetSelectedBase()
    {
        SetCurrentSelectBase(null);
    }

    public void ReverseBaseList()
    {
        Bases.Reverse();
    }

    public void ShowHideBaseFilter()
    {
        IsShowFilter = !IsShowFilter;
        if (IsShowFilter == true)
        {
            BeginAreaY = 220;
        }
        else
        {
            BeginAreaY = 110;
        }
    }

    public void SortBases(Comparer<Y> comparer)
    {
        sortedMethod = comparer;
        Bases.Sort(comparer);

        if (IsSortDescending == true)
        {
            ReverseBaseList();
        }
    }

    public void CreateBaseTypeInstance(Type t)
    {
        int baseId = BasesScriptableObject.Instance.Bases.Count > 0 ? BasesScriptableObject.Instance.Bases[BasesScriptableObject.Instance.Bases.Count - 1].Id + 1 : 0;

        Y info = (Y)System.Activator.CreateInstance(t);
        info.Id = baseId;

        SetCurrentSelectBase(info);
    }

    public void SaveBaseInstance()
    {
        BasesScriptableObject.Instance.UpdateBaseInstance(CurrentBase);
    }

    public void RemoveBase(Y info)
    {
        if (CurrentBase != null && CurrentBase.Id == info.Id)
        {
            ResetSelectedBase();
            ChangeState(State.NONE);
        }
        BasesScriptableObject.Instance.RemoveBaseInstance(info);
    }
}