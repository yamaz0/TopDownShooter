[System.Serializable]
public class StructureSlot
{
    Weapon weapon;
    int slotNumber;

    // public int WeaponId { get => weaponId; set => weaponId = value; }
    public int SlotNumber { get => slotNumber; set => slotNumber = value; }
    // public Weapon Weapon { get => weapon; set => weapon = value; }

    public StructureSlot(int number)
    {
        SlotNumber = number;
    }

    public void SetStructure()
    {
        // Weapon = w;
    }
}
