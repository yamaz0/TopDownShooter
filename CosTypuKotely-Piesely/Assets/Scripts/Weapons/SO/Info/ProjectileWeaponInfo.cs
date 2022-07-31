using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProjectileWeaponInfo : WeaponInfo
{
    [SerializeReference]
    private List<ProjectileBullet> bullets = new List<ProjectileBullet>();

    public List<ProjectileBullet> Bullets { get => bullets; set => bullets = value; }
    public ProjectileWeaponInfo()
    {

    }
    public ProjectileWeaponInfo(ProjectileWeaponInfo info) : base(info)
    {
        Bullets.AddRange(info.Bullets);
    }
}
