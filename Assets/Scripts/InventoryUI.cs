using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform GridSlotsParent;
    public GameObject SlotPrefab;



    void AddInventoryItemUI(ItemInstance itemInstance)
    {
       
    }

    public void ReloadInventoryUI()
    {
        foreach (ItemInstance instance in Inventory.Instance.items)
        {
            GameObject newSlot = Instantiate(SlotPrefab, GridSlotsParent);
        }
    }
}
