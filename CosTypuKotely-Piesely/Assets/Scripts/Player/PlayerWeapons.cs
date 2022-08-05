using System.Collections.Generic;
using UnityEngine;



public class WeaponsSelector
{
    [SerializeField]
    private List<WeaponSlot> weaponsSlots = new List<WeaponSlot>();

    public Counter CurrentSlotNumber { get; set; } = new Counter(0, 0, 9);

    public void AddWeaponToSlot(Weapon w)
    {
        CurrentSlotNumber.Increase();
        //TODO
    }

    public void NextSlot()
    {
        CurrentSlotNumber.Increase();
        ChangeWeapn();
    }

    public void PreviousSlot()
    {
        CurrentSlotNumber.Decrease();
        ChangeWeapn();
    }

    public void SetWeaponSlot(int slotIndex)
    {
        if (weaponsSlots[slotIndex].WeaponId == -1) return;

        CurrentSlotNumber.Set(slotIndex);
        ChangeWeapn();
    }
    private void ChangeWeapn()
    {
        Player.Instance.PlayerShoot.ChangeWeapon(weaponsSlots[CurrentSlotNumber.Value].WeaponId);//TODO tu bedzie cos innego
    }
}

public class WeaponSlot
{
    int weaponId;
    int slotNumber;

    public int WeaponId { get => weaponId; set => weaponId = value; }
    public int SlotNumber { get => slotNumber; set => slotNumber = value; }
}

[System.Serializable]
public class PlayerWeapons
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
        if (weapons[index].IsUnlocked == true && CurrentWeapon != weapons[index])//TODO zmienic to na SO albo w ogole na klase z przypisanowymi klawiszami
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
