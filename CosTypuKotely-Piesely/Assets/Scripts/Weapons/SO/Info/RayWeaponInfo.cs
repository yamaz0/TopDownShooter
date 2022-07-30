using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RayWeaponInfo : WeaponInfo
{
    [SerializeReference]
    private List<RayBullet> bullets = new List<RayBullet>();

    public List<RayBullet> Bullets { get => bullets; set => bullets = value; }

    public RayWeaponInfo(RayWeaponInfo info) : base(info)
    {
        Bullets.AddRange(info.Bullets);
    }
}
