using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WheelWeaponsElementUI : WheelElementUI
{
    [SerializeField]
    private Image icon;
    [SerializeField]
    private TMPro.TMP_Text weaponNameText;
    [SerializeField]
    private int slotIndex;

    public void Init(WeaponSlot slot)
    {
        slotIndex = slot.SlotNumber;
        // icon.sprite = slot.Weapon.Info.Icon;
        // weaponNameText.SetText(slot.Weapon.Info.Name);
    }

    public override void OnSelect(BaseEventData eventData)
    {
        Player.Instance.PlayerWeapons.ChangeWeapon(slotIndex);
    }
    public override void OnDeselect(BaseEventData eventData)
    {
        
    }
}
