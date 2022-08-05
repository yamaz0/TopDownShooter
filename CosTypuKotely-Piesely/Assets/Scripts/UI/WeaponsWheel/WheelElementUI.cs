using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class WheelElementUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(1.5f, 0.2f);
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1f, 0.2f);
    }

    public virtual void OnSelect(BaseEventData eventData)
    {

    }

    public virtual void OnDeselect(BaseEventData eventData)
    {

    }
}