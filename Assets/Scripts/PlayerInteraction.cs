using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public LayerMask interactableLayer;
    public float interactDistance;

    void Update()
    {
        if (Input.GetKeyDown(KeybindManager.Instance.Interact))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactDistance, interactableLayer))
            {
                Inventory.Instance.AddItem(hit.transform.GetComponent<ItemInScene>().item);
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
