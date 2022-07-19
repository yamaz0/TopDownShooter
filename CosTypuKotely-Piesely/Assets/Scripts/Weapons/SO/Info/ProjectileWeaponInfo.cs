using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProjectileWeaponInfo : WeaponInfo
{
    [SerializeReference]
    private List<ProjectileBullet> bullets;
}
