using System.Collections;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField]
    private StatUI hp;
    [SerializeField]
    private StatUI armor;
    [SerializeField]
    private StatUI gold;
    [SerializeField]
    private WeaponUpgradesShop weaponUpgradesShop;

    private void OnEnable()
    {
        hp.Init();
        armor.Init();
        gold.Init();
        weaponUpgradesShop.Refresh();
    }

    private void OnDisable()
    {
        hp.DetachEvents();
        armor.DetachEvents();
        gold.DetachEvents();
    }
}