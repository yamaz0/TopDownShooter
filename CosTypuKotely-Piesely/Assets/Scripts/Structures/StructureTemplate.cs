using UnityEngine;

public class StructureTemplate : MonoBehaviour
{
    [SerializeField]
    private Color canBuildColor;
    [SerializeField]
    private Color cannotBuildColor;
    [SerializeField]
    private LayerMask mask;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private BoxCollider2D colider;
    [SerializeField]
    private Transform placeTransform;


    public StructureInfo Info { get; private set; }
    public int ObjectsColliderNumber { get; private set; }
    public bool CanBuild { get; private set; }
    public Transform PlaceTransform { get => placeTransform; set => placeTransform = value; }

    private void FixedUpdate()
    {
        transform.position = PlaceTransform.position;
    }

    public void Init(StructureInfo infoBase)
    {
        if (infoBase == null)
        {
            gameObject.SetActive(false);
            return;
        }

        Info = infoBase;
        gameObject.SetActive(true);
        spriteRenderer.sprite = Info.UndamagedIcon;
        colider.size = Info.UndamagedIcon.rect.size / Info.UndamagedIcon.pixelsPerUnit;
    }

    public bool CheckConditions()
    {
        bool playerHaveGold = Player.Instance.PlayerStats.Gold.Value >= Info.Cost;
        return CanBuild && playerHaveGold;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & mask) != 0)
        {
            ObjectsColliderNumber++;
            SetBuildAvaible(false, cannotBuildColor);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & mask) != 0)
        {
            ObjectsColliderNumber--;

            if (ObjectsColliderNumber <= 0)
            {
                SetBuildAvaible(true, canBuildColor);
            }
        }
    }

    private void SetBuildAvaible(bool state, Color color)
    {
        CanBuild = state;
        spriteRenderer.color = color;
    }
}