using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Item : ScriptableObject
{
    new public string name;
    public int max_stack_count;
    public Sprite icon;
}
