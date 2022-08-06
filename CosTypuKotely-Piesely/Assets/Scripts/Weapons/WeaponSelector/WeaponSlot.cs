[System.Serializable]
public class WeaponSlot
{
    Weapon weapon;
    int slotNumber;

    // public int WeaponId { get => weaponId; set => weaponId = value; }
    public int SlotNumber { get => slotNumber; set => slotNumber = value; }
    public Weapon Weapon { get => weapon; set => weapon = value; }

    public WeaponSlot(int number)
    {
        SlotNumber = number;
    }

    public void SetWeapon(Weapon w)
    {
        Weapon = w;
    }
}
