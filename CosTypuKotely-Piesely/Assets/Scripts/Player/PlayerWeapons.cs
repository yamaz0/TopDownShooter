using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerWeapons
{
    [SerializeField]
    private WeaponsSelector weaponsSelector = new WeaponsSelector();
    public Weapon CurrentWeapon { get; set; }
    public WeaponsSelector WeaponsSelector { get => weaponsSelector; set => weaponsSelector = value; }

    public event System.Action<Weapon> OnWeaponChanged = delegate { };

    public void Init(List<int> weaponsId)
    {
        WeaponsSelector.Init();

        for (int i = 0; i < weaponsId.Count; i++)
        {
            int id = weaponsId[i];
            WeaponsSelector.AddWeapon(id, i);
        }
    }

    public void Reload()
    {
        CurrentWeapon.Magazine.ReloadCorutine();
    }

    public List<Weapon> GetWeapons()
    {
        List<Weapon> list = new List<Weapon>();

        foreach (var slot in WeaponsSelector.WeaponsSlots)
        {
            if (slot.Weapon != null)
                list.Add(slot.Weapon);
        }

        return list;
    }

    public void ChangeWeapon(int index)
    {
        WeaponsSelector.SetWeaponSlot(index);
    }

    public void ChangeWeapon(Weapon weapon)
    {
        if (weapon == null) return;
        CurrentWeapon?.gameObject.SetActive(false);
        CurrentWeapon = weapon;
        CurrentWeapon.gameObject.SetActive(true);
        OnWeaponChanged(CurrentWeapon);
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
