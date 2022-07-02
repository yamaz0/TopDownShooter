using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgradesShop : MonoBehaviour
{
    [SerializeField]
    private WeaponUpgrade upgradeTemplate;
    [SerializeField]
    private WeaponBuy unlockTemplate;
    [SerializeField]
    private Transform content;
    [SerializeField]
    private List<WeaponShop> weaponsUi;
    [SerializeField]
    private List<Weapon> weapons;

    public void Refresh()
    {
        for (int i = weaponsUi.Count - 1; i >= 0; i--)
        {
            Destroy(weaponsUi[i].gameObject);
        }

        weaponsUi.Clear();

        for (int i = 0; i < weapons.Count; i++)
        {
            WeaponShop template;

            if (weapons[i].IsUnlocked == true)
            {
                template = upgradeTemplate;
            }
            else
            {
                template = unlockTemplate;
            }

            WeaponShop newWeaponUI = Instantiate(template, content);
            newWeaponUI.gameObject.SetActive(true);
            newWeaponUI.Init(weapons[i]);

            weaponsUi.Add(newWeaponUI);
        }
    }
}
