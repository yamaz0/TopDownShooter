using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WeaponBuyShop : MonoBehaviour
{
    [SerializeField]
    private WeaponBuy buyTemplate;
    [SerializeField]
    private Transform content;
    [SerializeField]
    private List<WeaponBuy> weaponsUi;

    [Inject]
    private Player PlayerInstance { get; set; }

    private void OnEnable()
    {
        Refresh();
    }

    public void Refresh()
    {
        weaponsUi.ClearAndDestroy();
        List<int> shopWeaponsID = MapManager.Instance.Options.ShopWeaponsID;
        List<Weapon> weapons = new List<Weapon>(shopWeaponsID.Count);

        foreach (var id in shopWeaponsID)
        {
            List<Weapon> weapons1 = PlayerInstance.PlayerWeapons.GetWeapons();
            Weapon weapon = weapons1.Find(x => x.Info.Id == id);
            if (weapon != null) continue;

            WeaponInfo weaponInfo = WeaponsScriptableObject.Instance.GetWeaponInfoById(id);

            WeaponBuy newWeaponUI = Instantiate(buyTemplate, content);
            newWeaponUI.gameObject.SetActive(true);
            newWeaponUI.Init(weaponInfo);

            weaponsUi.Add(newWeaponUI);
        }
    }
}
