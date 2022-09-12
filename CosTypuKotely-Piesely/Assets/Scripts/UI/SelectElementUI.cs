using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectElementUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(1.5f, 0.2f);
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1f, 0.2f);
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {

    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {

    }
}