using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelWeaponsUI : WheelUI
{
    private void OnEnable() {
        List<WeaponSlot> weaponsSlots = Player.Instance.PlayerWeapons.WeaponsSelector.WeaponsSlots;
        int index = 0;
        foreach (WheelWeaponsElementUI element in Elements)
        {
            WeaponSlot weaponSlot = weaponsSlots[index];
            element.Init(weaponSlot);
        }
    }
}

public class WheelUI : MonoBehaviour
{
    [SerializeField]
    private List<WheelElementUI> elements;

    public List<WheelElementUI> Elements { get => elements; set => elements = value; }
}
