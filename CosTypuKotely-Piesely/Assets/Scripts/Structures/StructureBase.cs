using UnityEngine;

public enum StructureType { Baricade, Tower };

[RequireComponent(typeof(SpriteRenderer))]
public class StructureBase : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float healthPoints;
    [SerializeField]
    private StructureType type;

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private BoxCollider2D boxcollider;

    public StructureInfo Info { get; private set; }
    public float HealthPoints { get => healthPoints; set => healthPoints = value; }
    public StructureType Type { get => type; set => type = value; }

    public event System.Action OnDestroyed = delegate { };

    public void Build(StructureInfo info)
    {
        Info = info;
        gameObject.SetActive(true);
        spriteRenderer.sprite = Info.Icon;
        HealthPoints = info.Hp;
        spriteRenderer.sprite = info.Icon;
        transform.localScale = new Vector3(Info.Width, Info.Height, 1);
        // boxcollider.size = Info.UndamagedIcon.rect.size / Info.UndamagedIcon.pixelsPerUnit;
    }

    public void AddHp(float value)
    {
        HealthPoints += value;
        CheckHp();
    }

    private void CheckHp()
    {
        if (healthPoints <= 0)
        {
            OnDestroyed();
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float value)
    {
        AddHp(-1);
    }
}