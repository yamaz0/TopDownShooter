using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class WheelWeaponsElementUI : WheelElementUI
{
    [SerializeField]
    private Image icon;
    [SerializeField]
    private TMPro.TMP_Text weaponNameText;
    [SerializeField]
    private int slotIndex;
    public string slotWeaponName;

    [Inject]
    private Player PlayerInstance { get; set; }

    public void Init(WeaponSlot slot)
    {
        slotIndex = slot.SlotNumber;
        if (slot.Weapon == null) return;
        icon.sprite = slot.Weapon.Info.Icon;
        slotWeaponName = slot.Weapon.Info.Name;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        PlayerInstance.PlayerWeapons.ChangeWeapon(slotIndex);
        weaponNameText.SetText(slotWeaponName);
        WindowManager.Instance.ShowWeaponsWheel();
    }
    public override void OnPointerUp(PointerEventData eventData)
    {

    }
}
