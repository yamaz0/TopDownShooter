using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerShoot
{
    [SerializeField]
    private List<Weapon> weapon = new List<Weapon>();
    public Weapon CurrentWeapon { get; set; }

    public event System.Action<Weapon> OnWeaponChanged = delegate { };

    public void Init()
    {
        CurrentWeapon = weapon[0];
        CurrentWeapon.IsUnlocked = true;
        CurrentWeapon.gameObject.SetActive(true);
    }

    public void ChangeWeapon(int index)
    {
        if (weapon[index].IsUnlocked == true && CurrentWeapon != weapon[index])
        {
            CurrentWeapon.gameObject.SetActive(false);
            CurrentWeapon = weapon[index];
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
