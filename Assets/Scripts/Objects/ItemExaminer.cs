using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using System;

public class ItemExaminer : MonoBehaviour
{
    private static ItemExaminer instance;

    public string itemName;
    //public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public bool isCollected;

    [SerializeField] private GameObject examineUI;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescText;
    [SerializeField] private Image itemImage;
    [SerializeField] private Button collectButton;

    
    
    private Item item;
    private InventoryManager inventoryManager;
    //[SerializeField] private InventorySystem inventorySystem;

    

    /* [Header("Choices UI")]
    [SerializeField] private GameObject[] Pilihan;
    private TextMeshProUGUI[] choicesText; */

    //private Story currentStory;
    //private ItemData currentItem;
    private ObjectTrigger currentTrigger;
    public bool examineisplaying {get ; private set; }
    private void Awake()
    {
        if (instance != null){
            Debug.LogWarning("Ditemukan lebih dari satu itemexaminer script");
        }
        instance = this;
    }

    public static ItemExaminer GetInstance()
    {
        
        return instance;
    }
    public void Start()
    {
        examineisplaying = false;
        examineUI.SetActive (false);

        
    }

    public void ExamineItem(GameObject item, ObjectTrigger trigger){

        examineisplaying = true;
        examineUI.SetActive(true);
        currentTrigger = trigger;

        Item itemInfo = item.GetComponent<Item>();

        string itemName = itemInfo.GetItemName();
        string itemDescription = itemInfo.GetItemDescription();
        int quantity = itemInfo.GetItemQuantity();
        Sprite itemSprite = itemInfo.GetItemSprite();

        itemNameText.text = itemName;
        itemDescText.text = itemDescription;
        itemImage.sprite = itemSprite;

        collectButton.interactable = true;

        /* var playerInput= InputManager.GetInstance().GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap("UI"); */

        collectButton.onClick.RemoveAllListeners();
        collectButton.onClick.AddListener(() => {
        Debug.Log("Collect Button Clicked!");
        Debug.Log($"Item added to inventory: {itemName}");
        InventoryManager.GetInstance().AddItem(itemName, quantity, itemSprite, itemDescription);

        examineUI.SetActive(false);
        examineisplaying = false;

        if (currentTrigger != null)
        {
            currentTrigger.Collect(); //untuk hide gameobject setelah dicollect
        }

        /* var playerInput = InputManager.GetInstance().GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap("Player"); */

       });

        
    }

    /* public void ExamineItem(ItemData item, ObjectTrigger trigger)

{
   examineUI.SetActive(true);

   currentStory = null;

   currentItem = item;
   currentTrigger = trigger;
   currentStory = new Story(item.inkStoryAsset.text);


   string itemName = currentStory.variablesState["itemName"]?.ToString();
   string itemDesc = currentStory.variablesState["itemDescription"]?.ToString();

   itemNameText.text = itemName;
   itemDescText.text = itemDesc;
   itemImage.sprite = item.image;

   collectButton.interactable = true;

   var playerInput= InputManager.GetInstance().GetComponent<PlayerInput>();
   playerInput.SwitchCurrentActionMap("UI");

   collectButton.onClick.RemoveAllListeners();
   collectButton.onClick.AddListener(() => {
       Debug.Log("Collect Button Clicked!");
       CollectItem();

   });
   //collectButton.onClick.AddListener(CollectItem);


} */
    /* public void CollectItem(){
        
        InventoryManager.GetInstance().AddItem(itemName, quantity, itemSprite, itemDescription);
    } */
    /*  public void CollectItem()
     {
         Debug.Log("Collected: " + currentItem.itemID); */
    // Menambahkan item ke inventory
    //InventoryManager.GetInstance().AddItem(currentItem);

    /* InventorySystem inventory = InventorySystem;
    bool added = inventory.AddItem(currentItem); */
    //InventoryManager.Instance.inventorySystem.AddItem(currentItem);

    /* currentItem = null;
    currentStory = null;
    examineUI.SetActive(false);
    examineisplaying = false;
    if (currentTrigger != null)
    {
        currentTrigger.Collect(); //untuk hide gameobject setelah dicollect
    }


    var playerInput = InputManager.GetInstance().GetComponent<PlayerInput>();
    playerInput.SwitchCurrentActionMap("Player");

} */

}