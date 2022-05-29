using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bullets
{
    [SerializeField]
    private List<Bullet> bullets;

    public int CurrentWeaponLevel { get; private set; } = 0;
    public Bullet CurrentBullet { get; private set; }

    public void Init()
    {
        CurrentBullet = bullets[0];
    }

    public Bullet GetNextBullet()
    {
        return CurrentWeaponLevel + 1 < bullets.Count ? bullets[CurrentWeaponLevel + 1] : null;
    }

    public void SetNextBullet()
    {
        CurrentWeaponLevel++;
        CurrentBullet = bullets[CurrentWeaponLevel];
    }
}
