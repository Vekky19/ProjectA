using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    public GameObject buildingMenu;

    public Item StoneAxe;
    public Item Stone, Branch;


    public void CraftStoneAxe()
    {
        if (Inventory.Instance.HasItem(Stone, 2) && Inventory.Instance.HasItem(Branch, 1))
        {
            Inventory.Instance.RemoveItem(Stone);
            Inventory.Instance.RemoveItem(Stone);
            Inventory.Instance.RemoveItem(Branch);
            Inventory.Instance.AddItem(StoneAxe);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (buildingMenu.activeSelf)
            {
                buildingMenu.SetActive(false);

                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = false;
            }
            else
            {
                buildingMenu.SetActive(true);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
