using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class WheelStructureElementUI : SelectElementUI
{
    [SerializeField]
    private Image icon;
    [SerializeField]
    private TMPro.TMP_Text structureNameText;
    [SerializeField]
    private int slotIndex;
    public string slotStructureName;

    [Inject]
    private Player PlayerInstance { get; set; }

    public void Init(StructureSlot slot)
    {
        // slotIndex = slot.SlotNumber;
        // if (slot.Structure == null) return;
        // icon.sprite = slot.Structure.Info.Icon;
        // slotStructureName = slot.Structure.Info.Name;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        // PlayerInstance.PlayerBuild.SetCurrentStructureId(slotIndex);//TODO ustawienie wybranej struktury
        structureNameText.SetText(slotStructureName);
        WindowManager.Instance.ShowStructuresWheel();
    }
    public override void OnPointerUp(PointerEventData eventData)
    {

    }
}
