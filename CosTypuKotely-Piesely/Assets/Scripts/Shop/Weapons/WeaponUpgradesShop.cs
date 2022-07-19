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

    private void OnEnable()
    {
        Refresh();
    }

    public void Refresh()
    {
        weaponsUi.ClearAndDestroy();

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
