using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItemUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Canvas _canvas;
    public Image dragIcon;
    public GameObject dragObject;
    public int thisUIChild;

    void OnEnable()
    {
        _canvas = transform.root.GetComponent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (GetComponentInParent<UIItemSlot>().instance != null)
        {
            dragIcon.sprite = GetComponentInParent<UIItemSlot>().instance.item.icon;
        }

        dragObject = Instantiate(dragIcon.gameObject, _canvas.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragObject.GetComponent<RectTransform>().position = eventData.position;
        dragObject.GetComponent<RectTransform>().anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(dragObject);
    }
}
