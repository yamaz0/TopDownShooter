using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponInfo : BaseInfo
{
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private Cost unlockCost;
    [SerializeField]
    private int magazineSize;
    [SerializeField]
    private int fireRate;
    [SerializeReference]
    private List<Bullet> bullets = new List<Bullet>();

    public Sprite Icon { get => icon; set => icon = value; }
    public Cost UnlockCost { get => unlockCost; set => unlockCost = value; }
    public List<Bullet> Bullets { get => bullets; set => bullets = value; }
    public int MagazineSize { get => magazineSize; set => magazineSize = value; }
    public int FireRate { get => fireRate; set => fireRate = value; }

    public WeaponInfo()
    {

    }
    public WeaponInfo(WeaponInfo info) : base(info)
    {
        Icon = info.Icon;
        UnlockCost = info.UnlockCost;
        MagazineSize = info.MagazineSize;
        FireRate = info.FireRate;
        Bullets.AddRange(info.Bullets);
    }

}
