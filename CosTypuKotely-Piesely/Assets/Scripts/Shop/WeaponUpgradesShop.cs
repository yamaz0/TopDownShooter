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
            newWeaponUpgradeUI.gameObject.SetActive(true);
            newWeaponUpgradeUI.Init(weapons[i]);

            upgrades.Add(newWeaponUpgradeUI);
        }
    }
}
