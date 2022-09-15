using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponShop : MonoBehaviour
{

    [SerializeField]
    private Button button;

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

    protected Button Button { get => button; set => button = value; }
    protected TMP_Text DamageText { get => damageText; set => damageText = value; }
    protected TMP_Text FireRateText { get => fireRateText; set => fireRateText = value; }
    protected TMP_Text CostText { get => costText; set => costText = value; }
    protected Image Image { get => image; set => image = value; }
    protected Image Icon { get => icon; set => icon = value; }


    public virtual void OnButtonClick()
    {

    }

    public virtual void UpdateWeaponUI()
    {

    }
}
