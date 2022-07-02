using UnityEngine;
[System.Serializable]
public class StructureInfo : BaseInfo
{
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private float cost;
    [SerializeField]
    private float unlockCost;
    [SerializeField]
    private float hp;
    [SerializeField]
    private StructureType type;

    public Sprite Icon { get => icon; private set => icon = value; }
    public float Cost { get => cost; private set => cost = value; }
    public float Hp { get => hp; private set => hp = value; }
    public StructureType Type { get => type; set => type = value; }
    public float UnlockCost { get => unlockCost; set => unlockCost = value; }
}