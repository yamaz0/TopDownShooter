using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerShoot
{
    [SerializeField]
    private List<Weapon> weapon = new List<Weapon>();
    public Weapon CurrentWeapon { get; set; }


    public void Init()
    {
        CurrentWeapon = weapon[0];
        CurrentWeapon.gameObject.SetActive(true);
    }

    public void ChangeWeapon(int index)
    {
        if (weapon[index].IsUnlocked == true && CurrentWeapon != weapon[index])
        {
            CurrentWeapon.gameObject.SetActive(false);
            CurrentWeapon = weapon[index];
            CurrentWeapon.gameObject.SetActive(true);
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
