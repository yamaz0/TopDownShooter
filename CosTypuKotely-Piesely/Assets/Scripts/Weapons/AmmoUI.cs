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
        SetCurrentAmmo(CacheCurrentWeapon.CurrentMagazineSize);
        SetMaxAmmo(CacheCurrentWeapon.MagazineSize);

        Player.Instance.PlayerShoot.OnWeaponChanged += SetWeaponUI;
        AttachAmmoEvents();
    }

    private void AttachAmmoEvents()
    {
        CacheCurrentWeapon.OnMagazineSizeChanged += SetCurrentAmmo;
        CacheCurrentWeapon.OnMagazineMaxSizeChanged += SetMaxAmmo;
    }

    private void OnDisable()
    {
        Player.Instance.PlayerShoot.OnWeaponChanged -= SetWeaponUI;
        DetachAmmoEvents();
    }

    private void DetachAmmoEvents()
    {
        CacheCurrentWeapon.OnMagazineSizeChanged -= SetCurrentAmmo;
        CacheCurrentWeapon.OnMagazineMaxSizeChanged -= SetMaxAmmo;
    }

    public void SetWeaponUI(Weapon weapon)
    {
        DetachAmmoEvents();

        CacheCurrentWeapon = weapon;

        currentAmmoText.SetText(CacheCurrentWeapon.CurrentMagazineSize.ToString());
        maxAmmoText.SetText(CacheCurrentWeapon.MagazineSize.ToString());

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
