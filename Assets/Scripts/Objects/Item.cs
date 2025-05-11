using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    [SerializeField] string itemName;
    [TextArea]
    [SerializeField] string itemDescription;
    [SerializeField] int quantity;
    [SerializeField] Sprite itemSprite;

    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = GameObject.Find("Manager").GetComponentInChildren<InventoryManager>();
    }

    void Update()
    {
        
    }
    // Public getters
    public string GetItemName() => itemName;
    public string GetItemDescription() => itemDescription;
    public Sprite GetItemSprite() => itemSprite;
    public int GetItemQuantity() => quantity;

}
