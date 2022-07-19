using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RayWeaponInfo : WeaponInfo
{
    [SerializeReference]
    private List<RayBullet> bullets;
}
