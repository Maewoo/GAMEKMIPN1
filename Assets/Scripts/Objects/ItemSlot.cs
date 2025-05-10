using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    //== ITEM DATA ===
    /* public string itemName;
    public Sprite itemSprite;
    [TextArea (3, 10)]
    public string itemDescription; */
    public ItemData itemData;
    public bool isFull;

    //== ITEM SLOT ==
    [SerializeField] private Image itemImage;

    /* public void AddItem(string itemName, Sprite itemSprite){

    } */

    public void AddItem(ItemData itemData){
        this.itemData.defaultName = itemData.defaultName;
        this.itemData.image = itemData.image;
        this.itemData.itemID = itemData.itemID;
        isFull = true;
        itemImage.sprite = itemData.image;
    }
}
