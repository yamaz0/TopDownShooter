using UnityEngine;
[System.Serializable]
public class StructureInfo : BaseInfo
{
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private Cost buildCost;
    [SerializeField]
    private Cost unlockCost;
    [SerializeField]
    private float hp;
    [SerializeField]
    private StructureType type;

    public Sprite Icon { get => icon; private set => icon = value; }
    public Cost BuildCost { get => buildCost; private set => buildCost = value; }
    public float Hp { get => hp; private set => hp = value; }
    public StructureType Type { get => type; set => type = value; }
    public Cost UnlockCost { get => unlockCost; set => unlockCost = value; }

    public StructureInfo()
    {

    }

    public StructureInfo(StructureInfo info) : base(info)
    {
        Icon = info.Icon;
        BuildCost = info.BuildCost;
        Hp = info.Hp;
        Type = info.Type;
        UnlockCost = info.UnlockCost;
    }
}