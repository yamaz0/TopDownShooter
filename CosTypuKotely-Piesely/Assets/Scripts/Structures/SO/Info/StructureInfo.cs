using UnityEngine;
[System.Serializable]
public class StructureInfo : BaseInfo
{
    [SerializeField]
    private Sprite undamagedIcon;
    [SerializeField]
    private Sprite damagedIcon;
    [SerializeField]
    private float cost;
    [SerializeField]
    private float repairCost;
    [SerializeField]
    private float hp;

    public Sprite UndamagedIcon { get => undamagedIcon; private set => undamagedIcon = value; }
    public Sprite DamagedIcon { get => damagedIcon; private set => damagedIcon = value; }
    public float Cost { get => cost; private set => cost = value; }
    public float RepairCost { get => repairCost; private set => repairCost = value; }
    public float Hp { get => hp; private set => hp = value; }
}