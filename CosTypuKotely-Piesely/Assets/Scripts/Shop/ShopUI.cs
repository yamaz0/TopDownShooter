using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgradesShop : MonoBehaviour
{
    [SerializeField]
    private WeaponUpgrade template;
    [SerializeField]
    private Transform content;
    [SerializeField]
    private List<WeaponUpgrade> upgrades;
    [SerializeField]
    private List<Weapon> weapons;

    public void Refresh()
    {
        for (int i = upgrades.Count - 1; i >= 0; i--)
        {
            Destroy(upgrades[i]);
        }

        upgrades.Clear();

        for (int i = 0; i < weapons.Count; i++)
        {
            WeaponUpgrade newWeaponUpgradeUI = Instantiate(template, content);
            newWeaponUpgradeUI.Init(weapons[i]);

            upgrades.Add(newWeaponUpgradeUI);
        }
    }
}

public class ShopUI : MonoBehaviour
{
    [SerializeField]
    private StatUI hp;
    [SerializeField]
    private StatUI armor;
    [SerializeField]
    private StatUI gold;

    [SerializeField]
    private WeaponUpgrade weapon1;
    [SerializeField]
    private WeaponUpgrade weapon2;
    [SerializeField]
    private WeaponUpgrade weapon3;


    private void OnEnable()
    {
        hp.Init();
        armor.Init();
        gold.Init();

    }

    private void OnDisable()
    {
        hp.DetachEvents();
        armor.DetachEvents();
        gold.DetachEvents();
    }
}