using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerBuild
{
    [SerializeField]
    private bool isBuildMode = false;
    [SerializeField]
    private StructuresSelector selector;
    [SerializeField]
    private StructureTemplate structureTemplate;

    [SerializeField]
    private GameObject weaponUI;
    [SerializeField]
    private GameObject buildingUI;

    public bool IsBuildMode { get => isBuildMode; set => isBuildMode = value; }
    public StructureTemplate StructureTemplate { get => structureTemplate; set => structureTemplate = value; }
    public StructuresSelector Selector { get => selector; set => selector = value; }

    public event System.Action<StructureInfo> OnStructureUnlocked = delegate { };
    public event System.Action<StructureInfo> OnStructureChanged = delegate { };

    public void Init(List<int> unlockStrucutresIds)
    {
        foreach (var id in unlockStrucutresIds)
        {
            Selector.AddStructure(id);
        }
        SetCurrentStructureSlot(1);
        // WaveManager.Instance.OnWaveStart+=ShowTemplate;
    }

    public List<StructureInfo> GetStructures()
    {
        List<StructureInfo> list = new List<StructureInfo>();

        foreach (KeyValuePair<int, StructureSlot> slot in Selector.Slots)
        {
            // if (slot.Value.Structure != null)// tu chyba zbedne ale do przetestowania a jak cos to odkomentowac
            list.Add(slot.Value.Info);
        }

        return list;
    }

    public void UnlockStructure(int id)
    {
        StructureInfo info = StructureScriptableObject.Instance.GetStructureInfoById(id);
        Selector.AddStructure(info);
        OnStructureUnlocked(info);
    }

    public void ChangeMode()
    {
        IsBuildMode = !IsBuildMode;
        ShowTemplate(IsBuildMode);
    }

    public void ShowTemplate(bool activeState)
    {
        weaponUI.SetActive(!activeState);
        buildingUI.SetActive(activeState);
        StructureTemplate.gameObject.SetActive(activeState);
    }

    public void SetCurrentStructureSlot(int key)
    {
        StructureSlot slot = Selector.SetSlot(key);
        if (slot == null) return;
        StructureTemplate.Init(slot.Info);
        OnStructureChanged(slot.Info);
    }


    public void SetNextStructureSlot()
    {
        StructureSlot slot = Selector.NextSlot();

        StructureTemplate.Init(slot.Info);
        OnStructureChanged(slot.Info);
    }

    public void SetPreviousStructureSlot()
    {
        StructureSlot slot = Selector.PreviousSlot();

        StructureTemplate.Init(slot.Info);
        OnStructureChanged(slot.Info);
    }


    public void Build()
    {
        if (selector.Slots.Count > 0 && StructureTemplate.CheckConditions())
        {
            BuildManager.Instance.Build(StructureTemplate);
        }
    }
}
