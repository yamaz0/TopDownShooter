using System.Collections.Generic;
using UnityEngine;



public class WeaponsSelector
{
    [SerializeField]
    private List<WeaponSlot> weaponsSlots = new List<WeaponSlot>();

    public Counter CurrentSlotNumber { get; set; } = new Counter(0, 0, 9);
    public List<WeaponSlot> WeaponsSlots { get => weaponsSlots; set => weaponsSlots = value; }

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
        // if (WeaponsSlots[slotIndex].WeaponId == -1) return;

        CurrentSlotNumber.Set(slotIndex);
        ChangeWeapn();
    }
    private void ChangeWeapn()
    {
        // Player.Instance.PlayerWeapons.ChangeWeapon(WeaponsSlots[CurrentSlotNumber.Value].WeaponId);//TODO tu bedzie cos innego
    }
}

public class WeaponSlot
{
    Weapon weapon;
    int slotNumber;

    // public int WeaponId { get => weaponId; set => weaponId = value; }
    public int SlotNumber { get => slotNumber; set => slotNumber = value; }
    public Weapon Weapon { get => weapon; set => weapon = value; }
}

[System.Serializable]
public class PlayerWeapons
{
    [SerializeField]
    private List<Weapon> weapons = new List<Weapon>();
    [SerializeField]
    private WeaponsSelector weaponsSelector;
    public Weapon CurrentWeapon { get; set; }
    public WeaponsSelector WeaponsSelector { get => weaponsSelector; set => weaponsSelector = value; }

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
