using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    [SerializeField] string itemName;
    [SerializeField] Sprite sprite;

    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = GameObject.Find("Manager").GetComponent<InventoryManager>();
    }

    void Update()
    {
        
    }

}
