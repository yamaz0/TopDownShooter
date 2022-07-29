using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProjectileWeaponInfo : WeaponInfo
{
    [SerializeReference]
    private List<ProjectileBullet> bullets;

    public List<ProjectileBullet> Bullets { get => bullets; set => bullets = value; }
}
