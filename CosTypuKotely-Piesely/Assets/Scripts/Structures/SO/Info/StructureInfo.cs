using UnityEngine;
[System.Serializable]
public class StructureInfo : BaseInfo
{
    [SerializeField]
    private Sprite undamagedIcon;
    [SerializeField]
    private float cost;
    [SerializeField]
    private float hp;
    [SerializeField]
    private StructureType type;

    public Sprite UndamagedIcon { get => undamagedIcon; private set => undamagedIcon = value; }
    public float Cost { get => cost; private set => cost = value; }
    public float Hp { get => hp; private set => hp = value; }
    public StructureType Type { get => type; set => type = value; }
}