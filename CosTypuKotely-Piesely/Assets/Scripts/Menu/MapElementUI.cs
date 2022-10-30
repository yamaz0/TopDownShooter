using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class MapElementUI : SelectElementUI
{
    [SerializeField]
    private Image iconImage;
    [SerializeField]
    private TMPro.TMP_Text nameText;
    [SerializeField]
    private Image ramka;
    [SerializeField]
    private MapInfo info;

    public event System.Action<MapElementUI> OnMapElementClicked = delegate { };

    [Inject]
    public MapManager MapManagerInstance { get; set; }
    public MapInfo Info { get => info; set => info = value; }
    public bool Selected = false;

    public void Init(MapInfo slot)
    {
        Info = slot;
        iconImage.sprite = slot.Icon;
        nameText.SetText(slot.Name);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        // PlayerInstance.PlayerWeapons.ChangeWeapon(slotIndex);
        // weaponNameText.SetText(slotWeaponName);
        // WindowManager.Instance.ShowWeaponsWheel();
        // MapManagerInstance.SelectedMap = info;
        if (Selected == false)
        {
            SetSelected(true);
            // MapManagerInstance.SetMapInfo(info);//tutaj albo na koniec przy kliknieciu start
            OnMapElementClicked(this);
        }
    }

    public void SetSelected(bool state)
    {
        Selected = state;
        ramka.gameObject.SetActive(state);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
    }
}
