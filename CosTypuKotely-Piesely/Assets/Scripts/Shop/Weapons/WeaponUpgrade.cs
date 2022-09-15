using TMPro;
using UnityEngine;
using Zenject;

public class WeaponUpgrade : WeaponShop
{
    [SerializeField]
    private TMPro.TMP_Text levelWeaponText;
    [SerializeField]
    private TMPro.TMP_Text nextLevelWeaponText;
    [SerializeField]
    private TMPro.TMP_Text nextDamageText;

    protected TMP_Text LevelWeaponText { get => levelWeaponText; set => levelWeaponText = value; }
    protected TMP_Text NextLevelWeaponText { get => nextLevelWeaponText; set => nextLevelWeaponText = value; }
    protected TMP_Text NextDamageText { get => nextDamageText; set => nextDamageText = value; }

    public Weapon Weapon { get; set; }

    [Inject]
    private Player PlayerInstance { get; set; }

    public void Init(Weapon weapon)
    {
        Weapon = weapon;
        Icon.sprite = weapon.Info.Icon;
        UpdateWeaponUI();
    }

    public override void OnButtonClick()
    {
        if (Weapon.Bullets.GetNextBullet().UpgradeCost.TryBuy())
        {
            Weapon.UpgradeWeapon();
            UpdateWeaponUI();
        }
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
            CostText.SetText(nextBullet.UpgradeCost.Value.ToString());
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
