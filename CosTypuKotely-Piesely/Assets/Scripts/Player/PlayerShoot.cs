using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerShoot
{
    [SerializeField]
    private List<Weapon> weapons = new List<Weapon>();
    public Weapon CurrentWeapon { get; set; }

    public event System.Action<Weapon> OnWeaponChanged = delegate { };

    public void Init()
    {
        foreach (var weapon in weapons)
        {
            weapon.Init();
        }

        CurrentWeapon = weapons[0];
        CurrentWeapon.IsUnlocked = true;
        CurrentWeapon.gameObject.SetActive(true);
    }

    public void ChangeWeapon(int index)
    {
        if (weapons[index].IsUnlocked == true && CurrentWeapon != weapons[index])
        {
            CurrentWeapon.gameObject.SetActive(false);
            CurrentWeapon = weapons[index];
            CurrentWeapon.gameObject.SetActive(true);
            OnWeaponChanged(CurrentWeapon);
        }
    }

    public void Shoot()
    {
        CurrentWeapon.Shoot();
    }

    public void StopShoot()
    {
        CurrentWeapon.StopShoot();
    }
}
