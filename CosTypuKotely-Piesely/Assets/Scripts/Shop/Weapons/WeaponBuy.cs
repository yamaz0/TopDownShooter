using UnityEngine;

public class WeaponBuy : WeaponShop
{
    public override void UpdateWeaponUI()
    {
        Bullet currentBullet = Weapon.Bullets.CurrentBullet;
        Bullet nextBullet = Weapon.Bullets.GetNextBullet();
        int currentWeaponLevel = Weapon.Bullets.CurrentWeaponLevel;
        bool isNextBulletExist = nextBullet != null;

        FireRateText.SetText(Weapon.FireRate.ToString());
        CostText.SetText((currentWeaponLevel * 100 + 100).ToString());

        LevelWeaponText.SetText("0");
        DamageText.SetText("0");

        DamageText.SetText(currentBullet.Damage.ToString());
        NextLevelWeaponText.SetText("1");

        Button.gameObject.SetActive(isNextBulletExist);
    }

    public override void OnButtonClick()
    {
        if (Player.Instance.PlayerStats.Cash.Value < Weapon.Info.UnlockCost)
        {
            Debug.Log("Not enough cash.");
            return;
        }

        Player.Instance.PlayerStats.Cash.AddValue(-Weapon.Info.UnlockCost);
        Weapon.UnlockWeapon();
        UpdateWeaponUI();
    }
}
