using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyInfo : BaseInfo
{
       [SerializeField]
    private float hp;
    [SerializeField]
    private float dmg;
    [SerializeField]
    private float gold;
[SerializeField]
private Sprite icon;
    [SerializeField]
    private float speed;

    public float Hp { get => hp; set => hp = value; }
    public float Dmg { get => dmg; set => dmg = value; }
    public float Gold { get => gold; set => gold = value; }
    public Sprite Icon { get => icon; set => icon = value; }
    public float Speed { get => speed; set => speed = value; }

    public EnemyInfo()
    {

    }
    public EnemyInfo(EnemyInfo info) : base(info)
    {

    }

}
