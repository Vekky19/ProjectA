using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeybindManager : MonoBehaviour
{
    public static KeybindManager Instance;

    public void Awake()
    {
        Instance = this;
    }

    public KeyCode Interact;
    public KeyCode Sprint;
}
