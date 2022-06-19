using UnityEngine;

public enum StructureType { Baricade, Tower };

[RequireComponent(typeof(SpriteRenderer))]
public class StructureBase : MonoBehaviour
{
    [SerializeField]
    private float healthPoints;
    [SerializeField]
    private bool isDamaged;
    [SerializeField]
    private StructureType type;

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private BoxCollider2D boxcollider;

    public StructureInfo Info { get; private set; }
    public bool IsDamaged { get => isDamaged; set => isDamaged = value; }
    public float HealthPoints { get => healthPoints; set => healthPoints = value; }
    public StructureType Type { get => type; set => type = value; }

    public void AddHp(float value)
    {
        HealthPoints += value;
        CheckHp();
    }

    public void Build(StructureInfo info)
    {
        Info = info;
        gameObject.SetActive(true);
        spriteRenderer.sprite = Info.UndamagedIcon;
        SetUndamaged();
        // boxcollider.size = Info.UndamagedIcon.rect.size / Info.UndamagedIcon.pixelsPerUnit;
    }

    public void Demolish()
    {
        spriteRenderer.sprite = null;
        Destroy(gameObject);
    }

    public bool Repair()
    {
        Float playerGold = Player.Instance.PlayerStats.Gold;

        if (playerGold.Value < Info.RepairCost)
        {
            return false;
        }

        playerGold.AddValue(-Info.RepairCost);
        SetUndamaged();

        return true;
    }

    private void CheckHp()
    {
        if (healthPoints <= 0)
        {
            SetDamaged();
        }
    }

    private void SetDamaged()
    {
        SetStructureState(0, true, Info.DamagedIcon);
    }

    private void SetUndamaged()
    {
        SetStructureState(Info.Hp, false, Info.UndamagedIcon);
    }

    private void SetStructureState(float hp, bool damageState, Sprite icon)
    {
        HealthPoints = hp;
        IsDamaged = damageState;
        spriteRenderer.sprite = icon;
    }
}