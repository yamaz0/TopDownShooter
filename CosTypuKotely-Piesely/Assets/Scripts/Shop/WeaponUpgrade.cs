public class WeaponUpgrade : WeaponShop
{
    public override void OnButtonClick()
    {
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
        CostText.SetText((currentWeaponLevel * 100 + 100).ToString());

        DamageText.SetText(currentBullet.Damage.ToString());

        LevelWeaponText.SetText(currentWeaponLevel.ToString());

        if (isNextBulletExist == true)
        {
            NextDamageText.SetText(nextBullet.Damage.ToString());
            NextLevelWeaponText.SetText((currentWeaponLevel + 1).ToString());
        }
        else
        {
            NextDamageText.SetText("MAX");
            NextLevelWeaponText.SetText("MAX");
            Image.color = new UnityEngine.Color(0.2391734f,254717f,2390976f);
        }

        Button.gameObject.SetActive(isNextBulletExist);
    }
}
