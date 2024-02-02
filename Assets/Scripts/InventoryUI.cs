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
    public GameObject SelectedItemInfoObject;

    public void ReloadInventoryUI()
    {
        //Delete existing slots
        foreach (Transform child in GridSlotsParent)
        {
            child.GetChild(0).GetComponent<Image>().enabled = false;
            child.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
        }

        //Create new slots
        int i = 0;
        foreach (ItemInstance instance in Inventory.Instance.items)
        {
            Transform slot = GridSlotsParent.GetChild(instance.uiChild);

            slot.GetChild(0).GetComponent<Image>().enabled = true;

            slot.GetComponent<UIItemSlot>().instance = instance;
            slot.GetChild(0).GetComponent<Image>().sprite = instance.item.icon;
            slot.GetChild(1).GetComponent<TextMeshProUGUI>().text = instance.stack.ToString();
            i++;
        }
    }
}
