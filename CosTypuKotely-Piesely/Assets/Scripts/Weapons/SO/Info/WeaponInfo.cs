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

    public override void CopyValues(BaseInfo info)
    {
        Id = info.Id;
        Name = info.Name;
    }
}
