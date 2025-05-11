using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{  
    public string itemID;
    public string defaultName;
    public Sprite image;
    
    private InventoryManager inventoryManager;
    public TextAsset inkStoryAsset; // Link to the ink file for that item

    /* void OnEnable()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
    } */
    

}

