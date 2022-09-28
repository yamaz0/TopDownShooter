using UnityEngine;
using Zenject;

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
    public bool CanBuild { get; private set; } = true;
    public Transform PlaceTransform { get => placeTransform; set => placeTransform = value; }

    [Inject]
    private Player PlayerInstance { get; set; }

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
        spriteRenderer.sprite = Info.Icon;
        colider.size = Info.Icon.rect.size / Info.Icon.pixelsPerUnit;
    }

    public bool CheckConditions()
    {
        bool playerHaveGold = Info.BuildCost.TryBuy();
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