using UnityEngine;

public enum StructureType { Baricade, Tower };

[RequireComponent(typeof(SpriteRenderer))]
public class StructureBase<T> : MonoBehaviour where T: StructureInfo
{
    [SerializeField]
    private float healthPoints;
    [SerializeField]
    private bool isDamaged;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    public T Info { get; private set; }
    public bool IsDamaged { get => isDamaged; set => isDamaged = value; }
    public float HealthPoints { get => healthPoints; set => healthPoints = value; }

    public void AddHp(float value)
    {
        HealthPoints += value;
        CheckHp();
    }

    public void Build(StructureInfo info)
    {
        Info = (T)info;
        SetUndamaged();
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