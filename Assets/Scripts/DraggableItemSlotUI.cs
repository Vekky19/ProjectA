using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItemSlotUI : MonoBehaviour, IDropHandler
{
    public int uiChild;

    public void OnDrop(PointerEventData eventData)
    {
        foreach (ItemInstance instance in Inventory.Instance.items)
        {
            if (instance.uiChild == uiChild)
            {
                return;
            }
        }
        eventData.pointerDrag.GetComponentInParent<UIItemSlot>().instance.uiChild = uiChild;
        InventoryUI.Instance.ReloadInventoryUI();
    }
}
