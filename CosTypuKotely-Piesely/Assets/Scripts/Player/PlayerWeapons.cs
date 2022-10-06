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
        for (int i = 0; i < weaponsId.Count; i++)
        {
            int id = weaponsId[i];
            WeaponsSelector.AddWeapon(id);
        }
        ChangeWeapon(1);
    }

    public void Reload()
    {
        CurrentWeapon.Magazine.ReloadCorutine();
    }

    public List<Weapon> GetWeapons()
    {
        List<Weapon> list = new List<Weapon>();

        foreach (KeyValuePair<int, WeaponSlot> slot in WeaponsSelector.Slots)
        {
            // if (slot.Value.Weapon != null)// tu chyba zbedne ale do przetestowania a jak cos to odkomentowac
            list.Add(slot.Value.Weapon);
        }

        return list;
    }

    public void ChangeWeapon(int index)
    {
        WeaponSlot weaponSlot = WeaponsSelector.SetSlot(index);
        if (weaponSlot == null) return;//tutaj mozna dorobic jakies komunikaty ze brak broni albo dzwiek blednego wybrania borni
        ChangeWeapon(weaponSlot.Weapon);
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
