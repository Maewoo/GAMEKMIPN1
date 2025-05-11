using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //== ITEM DATA ===
    public string itemName;
    public Sprite itemSprite;
    [TextArea]
    public string itemDescription;
    public int quantity;
    //public ItemData itemData;
    public bool isFull;

    //== ITEM SLOT ==
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text quantityText;

    //=== ITEM DESCRIPTION === //
    public Image itemDescImage;
    public TMP_Text itemNametext;
    public TMP_Text itemDescText;

    public GameObject selectedSelect;
    public bool thisItemSelected;

    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
    }

    /* public void AddItem(string itemName, Sprite itemSprite){

    } */

    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription){
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;

        this.itemDescription = itemDescription;
        isFull = true;

        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        itemImage.sprite = itemSprite;
    }

    public void OnPointerClick(PointerEventData eventData){
        if(eventData.button== PointerEventData.InputButton.Left){
            OnLeftClick();
        }
    }

    public void OnLeftClick(){

        inventoryManager.DeselectAllSlots();
        selectedSelect.SetActive(true);
        thisItemSelected = true;
        itemNametext.text = itemName;
        itemDescText.text = itemDescription;
        itemDescImage.sprite = itemSprite;

    }
}

    
