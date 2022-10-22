using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class WheelStructureElementUI : SelectElementUI
{
    [SerializeField]
    private Image interactionImage;
    [SerializeField]
    private Image icon;
    [SerializeField]
    private TMPro.TMP_Text structureNameText;
    [SerializeField]
    private int slotIndex;
    public string slotStructureName;

    [Inject]
    private Player PlayerInstance { get; set; }

    private void OnEnable()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void Init(StructureSlot slot)
    {
        interactionImage.raycastTarget = true;
        slotIndex = slot.SlotNumber;
        if (slot.Info == null) return;
        icon.sprite = slot.Info.Icon;
        slotStructureName = slot.Info.Name;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        Player.Instance.PlayerBuild.SetCurrentStructureSlot(slotIndex);
        structureNameText.SetText(slotStructureName);
        WindowManager.Instance.ShowStructuresWheel();
    }
    public override void OnPointerUp(PointerEventData eventData)
    {

    }
}
