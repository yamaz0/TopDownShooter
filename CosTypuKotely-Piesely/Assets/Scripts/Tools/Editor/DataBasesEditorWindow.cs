using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;

abstract public class DataBasesEditorWindow : ScriptableSingleton<DataBasesEditorWindow>
{
    public enum State
    {
        NONE,
        CREATE,
        MODIFY
    }
    public abstract void Init();
    private int createWidth = 0;
    private bool isShowFilter = false;
    private bool isShowAllFields = false;
    private string searchString = string.Empty;
    private string searchStringField = string.Empty;
    private System.Type filterType = null;
    private Comparer<BaseInfo> sortedMethod = Comparer<BaseInfo>.Create((x, BaseInfo) => x.Id.CompareTo(BaseInfo.Id));
    private bool isSortDescending = false;
    private List<BaseInfo> bases = new List<BaseInfo>();

    private List<Type> baseInfoTypes;
    private State currentState = new State();
    private State previusState = new State();
    private BaseInfo currentBase = null;

    private int basesViewStartY = 110;

    public bool IsShowFilter { get => isShowFilter; set => isShowFilter = value; }
    public string SearchString { get => searchString; set => searchString = value; }
    public string SearchStringField { get => searchStringField; set => searchStringField = value; }
    public List<BaseInfo> Bases { get => bases; set => bases = value; }
    public List<Type> BaseInfoTypes { get => baseInfoTypes; set => baseInfoTypes = value; }
    public State CurrentState { get => currentState; set => currentState = value; }
    public State PreviusState { get => previusState; set => previusState = value; }
    public BaseInfo CurrentObjectInstance { get => currentBase; set => currentBase = value; }
    public int CreateWidth { get => createWidth; set => createWidth = value; }
    public int BeginAreaY { get => basesViewStartY; set => basesViewStartY = value; }
    public bool IsShowAllFields { get => isShowAllFields; set => isShowAllFields = value; }
    public Type FilterType { get => filterType; set => filterType = value; }
    public Comparer<BaseInfo> SortedMethod { get => sortedMethod; set => sortedMethod = value; }
    public bool IsSortDescending { get => isSortDescending; set => isSortDescending = value; }
    public IEditorWindowData DataInstance { get; set; }


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
    public void SetCurrentSelectBase(BaseInfo info)
    {
        CurrentObjectInstance = info;
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

    public void SortBases(Comparer<BaseInfo> comparer)
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
        int baseId = DataInstance.Objects.Count > 0 ? DataInstance.Objects[DataInstance.Objects.Count - 1].Id + 1 : 0;

        BaseInfo info = (BaseInfo)System.Activator.CreateInstance(t);
        info.Id = baseId;

        SetCurrentSelectBase(info);
    }

    public void SaveCurrentInstance()
    {
        DataInstance.UpdateBaseInstance(CurrentObjectInstance);
    }

    public void AddCurrentInstance()
    {
        DataInstance.AddBaseInstance(CurrentObjectInstance);
        ResetSelectedBase();
    }

    public void RemoveInstance(BaseInfo info)
    {
        if (CurrentObjectInstance != null && CurrentObjectInstance.Id == info.Id)
        {
            ResetSelectedBase();
            ChangeState(State.NONE);
        }
        DataInstance.RemoveBaseInstance(info);
    }
}