using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponShop : MonoBehaviour
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
    [SerializeField]
    private Image image;
    [SerializeField]
    private Image icon;

    protected Weapon Weapon { get => weapon; set => weapon = value; }
    protected Button Button { get => button; set => button = value; }
    protected TMP_Text LevelWeaponText { get => levelWeaponText; set => levelWeaponText = value; }
    protected TMP_Text NextLevelWeaponText { get => nextLevelWeaponText; set => nextLevelWeaponText = value; }
    protected TMP_Text NextDamageText { get => nextDamageText; set => nextDamageText = value; }
    protected TMP_Text DamageText { get => damageText; set => damageText = value; }
    protected TMP_Text FireRateText { get => fireRateText; set => fireRateText = value; }
    protected TMP_Text CostText { get => costText; set => costText = value; }
    protected Image Image { get => image; set => image = value; }
    protected Image Icon { get => icon; set => icon = value; }

    public virtual void Init(Weapon cweapon)
    {
        Weapon = cweapon;
        Icon.sprite = Weapon.Info.Icon;
        UpdateWeaponUI();
    }

    public virtual void OnButtonClick()
    {

    }

    public virtual void UpdateWeaponUI()
    {

    }
}
