using UnityEngine;
using Zenject;

public class WeaponUpgrade : WeaponShop
{
    [Inject]
    private Player PlayerInstance { get; set; }

    public override void OnButtonClick()
    {
        float upgradeCost = Weapon.Bullets.GetNextBullet().UpgradeCost;
        Float playerCash = PlayerInstance.PlayerStats.Cash;

        if (upgradeCost > playerCash.Value)
        {
            Debug.Log("Not enough cash");
            return;
        }

        playerCash.AddValue(-upgradeCost);
        Weapon.UpgradeWeapon();
        UpdateWeaponUI();
    }

    public override void UpdateWeaponUI()
    {
        Bullet currentBullet = Weapon.Bullets.CurrentBullet;
        Bullet nextBullet = Weapon.Bullets.GetNextBullet();
        int currentWeaponLevel = Weapon.Bullets.CurrentWeaponLevel;
        bool isNextBulletExist = nextBullet != null;

        FireRateText.SetText(Weapon.FireRate.ToString());
        DamageText.SetText(currentBullet.Damage.ToString());
        LevelWeaponText.SetText(currentWeaponLevel.ToString());

        if (isNextBulletExist == true)
        {
            CostText.SetText(nextBullet.UpgradeCost.ToString());
            NextDamageText.SetText(nextBullet.Damage.ToString());
            NextLevelWeaponText.SetText((currentWeaponLevel + 1).ToString());
        }
        else
        {
            NextDamageText.SetText("MAX");
            NextLevelWeaponText.SetText("MAX");
            Image.color = new UnityEngine.Color(0.2391734f, 254717f, 2390976f);
        }

        Button.gameObject.SetActive(isNextBulletExist);
    }
}
