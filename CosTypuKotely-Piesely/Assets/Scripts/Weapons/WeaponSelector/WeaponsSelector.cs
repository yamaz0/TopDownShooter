using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponsSelector
{
    [SerializeField]
    private Weapon weaponTemplate;
    [SerializeField]
    private Transform playerWeaponTransform;
    [SerializeReference]
    private List<WeaponSlot> weaponsSlots = new List<WeaponSlot>();

    public Counter CurrentSlotNumber { get; set; } = new Counter(0, 0, 9);
    public List<WeaponSlot> WeaponsSlots { get => weaponsSlots; set => weaponsSlots = value; }

    public void Init()
    {
        WeaponsSlots = new List<WeaponSlot>(10);
        for (int i = 0; i < 10; i++)
        {
            WeaponsSlots.Add(new WeaponSlot(i));
        }
    }

    public void AddWeaponToSlot(int weaponId)
    {
        WeaponInfo weaponInfo = WeaponsScriptableObject.Instance.GetWeaponInfoById(weaponId);
        AddWeaponToSlot(weaponInfo);
    }

    public void AddWeaponToSlot(WeaponInfo info)
    {
        Weapon newWeapon = GameObject.Instantiate(weaponTemplate, playerWeaponTransform);
        newWeapon.Init(info);
        newWeapon.gameObject.SetActive(true);//mozliwosc wycieku broni. bedzie kupiona ale nie bedzie przypisana xD//TODO do poprawy

        for (int i = 0; i < WeaponsSlots.Count; i++)
        {
            if (WeaponsSlots[i].Weapon == null)
            {
                WeaponsSlots[i].SetWeapon(newWeapon);
                newWeapon.IsUnlocked = true;
                CurrentSlotNumber.Set(i);
                ChangeWeapn();
                break;
            }
        }
    }

    public void NextSlot()
    {
        for (int i = 0; i < 10; i++)
        {
            CurrentSlotNumber.Increase();

            if (WeaponsSlots[CurrentSlotNumber.Value].Weapon != null)
            {
                break;
            }
        }

        ChangeWeapn();
    }

    public void PreviousSlot()
    {
        for (int i = 0; i < 10; i++)
        {
            CurrentSlotNumber.Decrease();

            if (WeaponsSlots[CurrentSlotNumber.Value].Weapon != null)
            {
                break;
            }
        }

        // CurrentSlotNumber.Decrease();
        ChangeWeapn();
    }

    public bool SetWeaponSlot(int slotIndex)
    {
        if (WeaponsSlots[slotIndex].Weapon == null || WeaponsSlots[slotIndex].Weapon.IsUnlocked == false) return false;

        CurrentSlotNumber.Set(slotIndex);
        ChangeWeapn();
        return true;
    }

    private void ChangeWeapn()
    {
        Player.Instance.PlayerWeapons.ChangeWeapon(WeaponsSlots[CurrentSlotNumber.Value].Weapon);
    }
}