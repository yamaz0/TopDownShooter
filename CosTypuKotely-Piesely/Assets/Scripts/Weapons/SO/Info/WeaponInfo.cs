using System.Collections;
using UnityEngine;

[System.Serializable]
public class WeaponInfo : BaseInfo
{
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private float unlockCost;
}
