using System.Collections;
using UnityEngine;

[System.Serializable]
public class WeaponInfo : BaseInfo
{
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private float unlockCost;

    public Sprite Icon { get => icon; set => icon = value; }
    public float UnlockCost { get => unlockCost; set => unlockCost = value; }
    public WeaponInfo()
    {

    }
    public WeaponInfo(WeaponInfo info) : base(info)
    {
        Icon = info.Icon;
        UnlockCost = info.UnlockCost;
    }
}
