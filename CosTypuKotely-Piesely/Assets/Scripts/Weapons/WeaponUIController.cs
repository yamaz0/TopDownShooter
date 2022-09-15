using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUIController : MonoBehaviour
{
    [SerializeField]
    private AmmoUI ammoUI;
    [SerializeField]
    private Image weaponIcon;

    private void Start()
    {
        SetWeaponIcon(Player.Instance.PlayerWeapons.CurrentWeapon);
        Player.Instance.PlayerWeapons.OnWeaponChanged += SetWeaponIcon;
    }

    private void OnDisable()
    {
        Player.Instance.PlayerWeapons.OnWeaponChanged -= SetWeaponIcon;
    }

    public void SetWeaponIcon(Weapon w)
    {
        weaponIcon.sprite = w.Info.Icon;
    }
}
