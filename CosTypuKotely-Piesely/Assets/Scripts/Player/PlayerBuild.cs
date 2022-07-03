using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerBuild
{
    [SerializeField]
    private bool isBuildMode = false;
    [SerializeField]
    private List<int> unlockStructureIds;
    [SerializeField]
    private StructureTemplate structureTemplate;

    [SerializeField]
    private int currentStructureId;

    public bool IsBuildMode { get => isBuildMode; set => isBuildMode = value; }
    public List<int> UnlockStructureIds { get => unlockStructureIds; set => unlockStructureIds = value; }
    public int CurrentStructureId { get => currentStructureId; set => currentStructureId = value; }
    public StructureTemplate StructureTemplate { get => structureTemplate; set => structureTemplate = value; }
    public event System.Action<int> OnStructureUnlocked = delegate { };

    public void Init()
    {
        if (UnlockStructureIds == null)
        {
            UnlockStructureIds = new List<int> { 0 };
        }

        SetCurrentStructureId(UnlockStructureIds[0]);
        // WaveManager.Instance.OnWaveStart+=ShowTemplate;
    }

    public void UnlockStructure(int id)
    {
        UnlockStructureIds.Add(id);
        OnStructureUnlocked(id);
    }

    public void ChangeMode()
    {
        IsBuildMode = !IsBuildMode;
        ShowTemplate(IsBuildMode);
    }

    public void ShowTemplate(bool activeState)
    {
        StructureTemplate.gameObject.SetActive(activeState);
    }

    public void SetCurrentStructureId(int id)
    {
        if (UnlockStructureIds.Contains(id) == true)
        {
            CurrentStructureId = id;
        }
        else
        {
            CurrentStructureId = -1;
        }

        StructureInfo info = StructureScriptableObject.Instance.GetStructureInfoById(CurrentStructureId);
        StructureTemplate.Init(info);
    }

    public void Build()
    {
        if (CurrentStructureId != -1 && StructureTemplate.CheckConditions())
        {
            BuildManager.Instance.Build(StructureTemplate);
        }
    }
}
