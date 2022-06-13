using UnityEngine;

[System.Serializable]
public class TowerInfo : StructureInfo
{
    [SerializeField]
    private float dmg;
    [SerializeField]
    private float fireRate;

    public float Dmg { get => dmg; set => dmg = value; }
    public float FireRate { get => fireRate; set => fireRate = value; }
}