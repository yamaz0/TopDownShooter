using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponsSelector
{
    private const int SLOT_COUNT = 10;
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
        if (WeaponsSlots != null && WeaponsSlots.Count == SLOT_COUNT)
        {
            for (int i = 0; i < SLOT_COUNT; i++)
            {
                Weapon w = WeaponsSlots[i].Weapon;
                if (w != null) { GameObject.Destroy(w); }
            }
        }
        else
        {
            WeaponsSlots = new List<WeaponSlot>(SLOT_COUNT);

            for (int i = 0; i < SLOT_COUNT; i++)
            {
                WeaponsSlots.Add(new WeaponSlot(i));
            }
        }
    }

    public void AddWeaponToSlot(int weaponId, int slotIndex = 1)
    {
        WeaponInfo weaponInfo = WeaponsScriptableObject.Instance.GetWeaponInfoById(weaponId);
        AddWeaponToSlot(weaponInfo, slotIndex);
    }

    public void AddWeaponToSlot(WeaponInfo info, int slotIndex = 1)
    {
        Weapon newWeapon = GameObject.Instantiate(weaponTemplate, playerWeaponTransform);
        newWeapon.Init(info);
        newWeapon.gameObject.SetActive(true);//mozliwosc wycieku broni. bedzie kupiona ale nie bedzie przypisana xD//TODO do poprawy

        SetWeaponToIndexOrFirstEmpty(newWeapon, slotIndex);
    }

    private void SetWeaponToIndexOrFirstEmpty(Weapon newWeapon, int slotIndex)//TODO sprobowac przerobic na ladniejsze
    {
        if (WeaponsSlots[slotIndex].Weapon == null)//jesli docelowy slot jest pusty
        {
            SetWeaponToSlot(newWeapon, slotIndex);
        }
        else//jesli nie jest pusty to znajdz pusty ale od pierwszego slotu a na koncu osobno sprawdz zerowy
        {
            for (int i = 1; i < WeaponsSlots.Count; i++)
            {
                if (WeaponsSlots[i].Weapon == null)
                {
                    SetWeaponToSlot(newWeapon, i);
                    return;
                }
            }

            if (WeaponsSlots[0].Weapon == null)
            {
                SetWeaponToSlot(newWeapon, 0);
            }
        }
    }

    private void SetWeaponToSlot(Weapon newWeapon, int i)
    {
        WeaponsSlots[i].SetWeapon(newWeapon);
        newWeapon.IsUnlocked = true;
        CurrentSlotNumber.Set(i);
        ChangeWeapn();
    }

    public void NextSlot()
    {
        for (int i = 0; i < SLOT_COUNT; i++)
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
        for (int i = 0; i < SLOT_COUNT; i++)
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