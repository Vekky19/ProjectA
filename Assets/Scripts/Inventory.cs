using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<ItemInstance> items = new List<ItemInstance>();

    public GameObject InventoryUI;
    public StarterAssets.FirstPersonController FPC;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (InventoryUI.activeSelf)
            {
                InventoryUI.SetActive(false);
                FPC.enabled = true;

                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                InventoryUI.SetActive(true);
                FPC.enabled = false;

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
    }

    public void AddItem(Item newItem)
    {
        List<ItemInstance> hasThisItem = new List<ItemInstance>();

        foreach (ItemInstance itemInstance in items)
        {
            if (itemInstance.item == newItem)
            {
                hasThisItem.Add(itemInstance);
            }
        }

        if (hasThisItem.Count > 0)
        {//item exists in inventory, check if we can add to those stacks
            bool searchingForStackToAddTo = true;
            for (int i = 0; i < hasThisItem.Count; i++)
            {
                if (searchingForStackToAddTo)
                {
                    if (hasThisItem[i].stack < hasThisItem[i].item.max_stack_count)
                    {
                        items[items.IndexOf(hasThisItem[i])].stack += 1;
                        searchingForStackToAddTo = false;
                    }
                }
            }

            //couldnt add to any stacks, create new iteminstance
            if (searchingForStackToAddTo == true)
            {
                CreateNewInstance(newItem);
            }
        }
        else
        {
            //item not in inventory, create new iteminstance
            CreateNewInstance(newItem);
        }
    }

    public void RemoveItem(Item removeItem)
    {
        List<ItemInstance> hasThisItem = new List<ItemInstance>();

        foreach (ItemInstance itemInstance in items)
        {
            if (itemInstance.item == removeItem)
            {
                hasThisItem.Add(itemInstance);
            }
        }

        ItemInstance lowestInstance = hasThisItem[0];
        foreach (ItemInstance itemInstance in hasThisItem)
        {//find the instance that has the lowest stack of the item
            if (itemInstance.stack < lowestInstance.stack)
            {
                lowestInstance = itemInstance;
            }
        }

        items[items.IndexOf(lowestInstance)].stack -= 1;

        if (items[items.IndexOf(lowestInstance)].stack < 1)
        {//stack is now at zero, remove instance from the inventory
            items.RemoveAt(items.IndexOf(lowestInstance));
        }
    }

    public void CreateNewInstance(Item item)
    {
        ItemInstance newInstance = new ItemInstance(item, 1);
        items.Add(newInstance);
    }
}
