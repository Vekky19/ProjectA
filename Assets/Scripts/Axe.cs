using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour, IEquipable
{
    public ItemInstance instance;

    [Header("Axe Stats")]
    public float durability = 100f;
    public float damage = 13f;

    [Header("References")]
    public GameObject axeObject;

    [Header("Info")]
    public bool equipped = false;

    public void Equip()
    {
        axeObject.SetActive(true);
        axeObject.GetComponent<MeshRenderer>().enabled = true;
        equipped = true;
    }

    public void Unequip()
    {
        axeObject.SetActive(false);
        axeObject.GetComponent<MeshRenderer>().enabled = false;
        equipped = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SwingAxe();
        }
    }

    public void SwingAxe()
    {
        
    }
}
