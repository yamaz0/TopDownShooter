using UnityEngine;
[System.Serializable]
public class StructureInfo : BaseInfo
{
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private AnimationCurve cost;
    [SerializeField]
    private float unlockCost;
    [SerializeField]
    private float hp;
    [SerializeField]
    private StructureType type;

    public Sprite Icon { get => icon; private set => icon = value; }
    public AnimationCurve Cost { get => cost; private set => cost = value; }
    public float Hp { get => hp; private set => hp = value; }
    public StructureType Type { get => type; set => type = value; }
    public float UnlockCost { get => unlockCost; set => unlockCost = value; }
public StructureInfo()
{
    
}
    public StructureInfo(StructureInfo info) : base(info)
    {
        Icon = info.Icon;
        Cost = info.Cost;
        Hp = info.Hp;
        Type = info.Type;
        UnlockCost = info.UnlockCost;
    }
}