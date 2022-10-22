using UnityEngine;

[System.Serializable]
public class StructureSlot : Slot
{
    [SerializeField]
    private StructureInfo info;

    public StructureInfo Info { get => info; set => info = value; }
    // public int WeaponId { get => weaponId; set => weaponId = value; }
    // public Weapon Weapon { get => weapon; set => weapon = value; }

    public StructureSlot(int number) : base(number)
    {
        SlotNumber = number;
    }


    public void SetStructure(StructureInfo i)
    {
        Info = i;
    }
}
