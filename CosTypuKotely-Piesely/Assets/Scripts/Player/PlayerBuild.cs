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

    public void Init()
    {
        if (UnlockStructureIds == null)
        {
            UnlockStructureIds = new List<int> { 0 };
        }

        CurrentStructureId = UnlockStructureIds[0];
    }

    public void ChangeMode()
    {
        IsBuildMode = !IsBuildMode;
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
