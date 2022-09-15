using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WeaponUpgradesShop : MonoBehaviour
{
    [SerializeField]
    private WeaponUpgrade upgradeTemplate;

    [SerializeField]
    private Transform content;
    [SerializeField]
    private List<WeaponUpgrade> weaponsUi;

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
            WeaponUpgrade newWeaponUI = Instantiate(upgradeTemplate, content);
            newWeaponUI.gameObject.SetActive(true);
            newWeaponUI.Init(weapons[i]);

            weaponsUi.Add(newWeaponUI);
        }
    }
}
