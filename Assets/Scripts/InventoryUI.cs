using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    private void Awake()
    {
        Instance = this;
    }

    public Transform GridSlotsParent;
    public GameObject SlotPrefab;

    public void ReloadInventoryUI()
    {
        //Delete existing slots
        foreach (Transform child in GridSlotsParent)
        {
            Destroy(child.gameObject);
        }

        //Create new slots
        foreach (ItemInstance instance in Inventory.Instance.items)
        {
            Transform slot = Instantiate(SlotPrefab, GridSlotsParent).transform;

            slot.GetChild(0).GetComponent<Image>().sprite = instance.item.icon;
            slot.GetChild(1).GetComponent<TextMeshProUGUI>().text = instance.item.name;
            slot.GetChild(2).GetComponent<TextMeshProUGUI>().text = instance.stack.ToString();
        }
    }
}
