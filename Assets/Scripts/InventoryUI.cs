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
    public GameObject UseButtonObject;
    public GameObject PlayerHand;

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

            slot.GetComponent<Button>().onClick.AddListener(() => ShowSelectedItemInfo(instance));

            slot.GetComponent<UIItemSlot>().instance = instance;
            slot.GetChild(0).GetComponent<Image>().sprite = instance.item.icon;
            slot.GetChild(1).GetComponent<TextMeshProUGUI>().text = instance.item.name;
            slot.GetChild(2).GetComponent<TextMeshProUGUI>().text = instance.stack.ToString();
        }
    }

    public void ShowSelectedItemInfo(ItemInstance instance)
    {
        SelectedItemInfoObject.SetActive(true);
        SelectedItemInfoObject.transform.GetChild(0).GetComponent<Image>().sprite = instance.item.icon;
        SelectedItemInfoObject.GetComponent<UIItemSlot>().instance = instance;

        if (instance.item.equipable)
        {
            UseButtonObject.SetActive(true);
        }
        else
        {
            UseButtonObject.SetActive(false);
        }
    }

    public void DropButton()
    {
        ItemInstance instance = SelectedItemInfoObject.GetComponent<UIItemSlot>().instance;
        if (instance.stack == 1)
        {///Hide Menu when we drop the last item of the stack
            SelectedItemInfoObject.SetActive(false);
        }
        Inventory.Instance.DropItem(instance.item);
    }

    public void UseButton()
    {
        
    }
}
