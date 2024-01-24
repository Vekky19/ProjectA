using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    public GameObject buildingMenu;

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
