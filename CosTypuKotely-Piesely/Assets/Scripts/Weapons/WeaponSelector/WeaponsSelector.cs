using UnityEngine;

[System.Serializable]
public class WeaponsSelector : Selector<WeaponSlot>
{
    [SerializeField]
    private Weapon weaponTemplate;
    [SerializeField]
    private Transform playerWeaponTransform;


    // [Inject]
    // private Player PlayerInstance { get; set; }


    public void AddWeapon(int weaponId)
    {
        WeaponInfo weaponInfo = WeaponsScriptableObject.Instance.GetWeaponInfoById(weaponId);
        AddWeapon(weaponInfo);
    }

    public void AddWeapon(WeaponInfo info)
    {
        Weapon newWeapon = GameObject.Instantiate(weaponTemplate, playerWeaponTransform);
        newWeapon.Init(info);
        newWeapon.gameObject.SetActive(true);//mozliwosc wycieku broni. bedzie kupiona ale nie bedzie przypisana xD//TODO do poprawy
        AddSlot(newWeapon);
    }

    private void AddSlot(Weapon newWeapon)
    {
        int index = Slots.Count + 1;
        WeaponSlot s = new WeaponSlot(index);
        // CurrentSlotNumber.Set(index);
        CurrentSlotNumber.SetMax(index);
        s.SetWeapon(newWeapon);
        Slots.Add(index, s);
    }

    // private void ChangeWeapon()
    // {
    //     Player.Instance.PlayerWeapons.ChangeWeapon(Slots[CurrentSlotNumber.Value].Weapon);
    // }
}