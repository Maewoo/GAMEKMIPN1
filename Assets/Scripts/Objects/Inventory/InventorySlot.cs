using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    public ItemData item;
    public int quantity;

    public bool IsEmpty => item == null;

    public void Clear()
    {
        item = null;
        quantity = 0;
    }
}
