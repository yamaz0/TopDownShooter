using System.Collections.Generic;
using UnityEngine;
using Zenject;

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

    [Inject]
    private Player PlayerInstance { get; set; }

    private void OnEnable()
    {
        Refresh();
    }

    public void Refresh()
    {
        weaponsUi.ClearAndDestroy();
        List<Weapon> weapons = PlayerInstance.PlayerWeapons.GetWeapons();

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
