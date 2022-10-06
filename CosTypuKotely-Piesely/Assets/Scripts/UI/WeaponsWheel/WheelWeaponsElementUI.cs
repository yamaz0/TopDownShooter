using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class WheelWeaponsElementUI : SelectElementUI
{
    [SerializeField]
    private Image interactionImage;
    [SerializeField]
    private Image icon;
    [SerializeField]
    private TMPro.TMP_Text weaponNameText;
    [SerializeField]
    private int slotIndex;
    public string slotWeaponName;

    [Inject]
    private Player PlayerInstance { get; set; }

    private void OnEnable()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void Init(WeaponSlot slot)
    {
        interactionImage.raycastTarget = true;
        slotIndex = slot.SlotNumber;
        if (slot.Weapon == null) return;//todo nigdy tu nie powinno byc nulla
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
