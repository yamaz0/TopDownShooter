using UnityEngine;
using Zenject;

public class WeaponBuy : WeaponShop
{
    public WeaponInfo WeaponInfo { get; set; }

    [Inject]
    private Player PlayerInstance { get; set; }

    public void Init(WeaponInfo weaponInfo)
    {
        WeaponInfo = weaponInfo;
        Icon.sprite = weaponInfo.Icon;
        UpdateWeaponUI();
    }

    public override void UpdateWeaponUI()
    {
        FireRateText.SetText(WeaponInfo.FireRate.ToString());
        CostText.SetText(WeaponInfo.UnlockCost.Value.ToString());
        DamageText.SetText(WeaponInfo.Bullets[0].Damage.ToString());
    }

    public override void OnButtonClick()
    {
        if (WeaponInfo.UnlockCost.TryBuy())
        {
            Player.Instance.PlayerWeapons.WeaponsSelector.AddWeapon(WeaponInfo);
            // UpdateWeaponUI();//TODO Refresh shop
        }
        else
        {
            Debug.Log("Not enough cash.");
            return;
        }
    }
}
