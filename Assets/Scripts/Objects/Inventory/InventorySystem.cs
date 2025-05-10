using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Inventory System")]
public class InventorySystem : ScriptableObject
{
    public List<InventorySlot> slots = new List<InventorySlot>();

    public void Initialize(int size)
    {
        slots.Clear();
        for (int i = 0; i < size; i++)
        {
            slots.Add(new InventorySlot());
        }
    }

    public bool AddItem(ItemData itemData, int quantity = 1)
    {
        // Try to stack the item
        foreach (var slot in slots)
        {
            if (slot.item == itemData)
            {
                slot.quantity += quantity;
                return true;
            }
        }

        // Try to find an empty slot
        foreach (var slot in slots)
        {
            if (slot.IsEmpty)
            {
                slot.item = itemData;
                slot.quantity = quantity;
                return true;
            }
        }

        // Inventory is full
        return false;
    }

    public void RemoveItem(ItemData itemData, int quantity = 1)
    {
        foreach (var slot in slots)
        {
            if (slot.item == itemData)
            {
                slot.quantity -= quantity;
                if (slot.quantity <= 0)
                {
                    slot.Clear();
                }
                return;
            }
        }
    }
}
