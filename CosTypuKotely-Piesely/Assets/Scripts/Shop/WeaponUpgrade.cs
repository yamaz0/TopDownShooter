using UnityEngine;
using UnityEngine.UI;

public class WeaponUpgrade : MonoBehaviour
{
    [SerializeField]
    private Weapon weapon;
    [SerializeField]
    private Button button;
    [SerializeField]
    private TMPro.TMP_Text levelWeaponText;
    [SerializeField]
    private TMPro.TMP_Text nextLevelWeaponText;
    [SerializeField]
    private TMPro.TMP_Text nextDamageText;
    [SerializeField]
    private TMPro.TMP_Text damageText;
    [SerializeField]
    private TMPro.TMP_Text fireRateText;
    [SerializeField]
    private TMPro.TMP_Text costText;

    private void OnEnable()
    {
        UpdateWeaponUpgradeUI();
    }

    public void UpdateWeaponUpgradeUI()
    {
        Bullet currentBullet = weapon.Bullets.CurrentBullet;
        Bullet nextBullet = weapon.Bullets.GetNextBullet();
        int currentWeaponLevel = weapon.Bullets.CurrentWeaponLevel;
        bool isNextBulletExist = nextBullet != null;

        fireRateText.SetText(weapon.FireRate.ToString());
        costText.SetText((currentWeaponLevel * 100 + 100).ToString());

        damageText.SetText(currentBullet.Damage.ToString());

        levelWeaponText.SetText(currentWeaponLevel.ToString());

        if (isNextBulletExist == true)
        {
            nextDamageText.SetText(nextBullet.Damage.ToString());
            nextLevelWeaponText.SetText((currentWeaponLevel + 1).ToString());
        }

        button.gameObject.SetActive(isNextBulletExist);
    }

    public void OnButtonClick()
    {
        weapon.UpgradeWeapon();
        UpdateWeaponUpgradeUI();
    }
}
