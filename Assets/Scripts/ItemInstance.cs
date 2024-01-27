using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ItemInstance : ScriptableObject
{
    public Item item;
    public int stack;
    public int uiChild;

    public ItemInstance(Item i, int s)
    {
        item = i;
        stack = s;
    }
}
