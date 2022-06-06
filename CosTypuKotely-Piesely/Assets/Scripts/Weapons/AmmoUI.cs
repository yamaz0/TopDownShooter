using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text currentAmmoText;
    [SerializeField]
    private TMPro.TMP_Text maxAmmoText;
    Weapon CacheCurrentWeapon { get; set; }
    private void Start()
    {
        CacheCurrentWeapon = Player.Instance.PlayerShoot.CurrentWeapon;
        SetWeaponUI(CacheCurrentWeapon);
        SetCurrentAmmo(CacheCurrentWeapon.Magazine.CurrentMagazineSize);
        SetMaxAmmo(CacheCurrentWeapon.Magazine.MagazineMaxSize);

        Player.Instance.PlayerShoot.OnWeaponChanged += SetWeaponUI;
        AttachAmmoEvents();
    }

    private void AttachAmmoEvents()
    {
        CacheCurrentWeapon.Magazine.OnMagazineSizeChanged += SetCurrentAmmo;
        CacheCurrentWeapon.Magazine.OnMagazineMaxSizeChanged += SetMaxAmmo;
    }

    private void OnDisable()
    {
        Player.Instance.PlayerShoot.OnWeaponChanged -= SetWeaponUI;
        DetachAmmoEvents();
    }

    private void DetachAmmoEvents()
    {
        CacheCurrentWeapon.Magazine.OnMagazineSizeChanged -= SetCurrentAmmo;
        CacheCurrentWeapon.Magazine.OnMagazineMaxSizeChanged -= SetMaxAmmo;
    }

    public void SetWeaponUI(Weapon weapon)
    {
        DetachAmmoEvents();

        CacheCurrentWeapon = weapon;

        currentAmmoText.SetText(CacheCurrentWeapon.Magazine.CurrentMagazineSize.ToString());
        maxAmmoText.SetText(CacheCurrentWeapon.Magazine.MagazineMaxSize.ToString());

        AttachAmmoEvents();
    }

    public void SetCurrentAmmo(int ammo)
    {
        currentAmmoText.SetText(ammo.ToString());
    }

    public void SetMaxAmmo(int ammo)
    {
        maxAmmoText.SetText(ammo.ToString());
    }
}
