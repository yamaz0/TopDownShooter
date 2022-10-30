using UnityEngine;
using Zenject;

public class AmmoUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text currentAmmoText;
    [SerializeField]
    private TMPro.TMP_Text maxAmmoText;
    Weapon CacheCurrentWeapon { get; set; }

    [Inject]
    private Player PlayerInstance { get; set; }

    private void OnEnable()
    {
        CacheCurrentWeapon = PlayerInstance.PlayerWeapons.CurrentWeapon;
        SetWeaponUI(CacheCurrentWeapon);
        SetCurrentAmmo(CacheCurrentWeapon.Magazine.CurrentMagazineSize);
        SetMaxAmmo(CacheCurrentWeapon.Magazine.MagazineMaxSize);

        PlayerInstance.PlayerWeapons.OnWeaponChanged += SetWeaponUI;
        // AttachAmmoEvents();
    }

    private void AttachAmmoEvents()
    {
        CacheCurrentWeapon.Magazine.OnMagazineSizeChanged += SetCurrentAmmo;
        CacheCurrentWeapon.Magazine.OnMagazineMaxSizeChanged += SetMaxAmmo;
    }

    private void OnDisable()
    {
        PlayerInstance.PlayerWeapons.OnWeaponChanged -= SetWeaponUI;
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
