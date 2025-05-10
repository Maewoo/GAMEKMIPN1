using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{

    [SerializeField] GameObject InvPanel;
    private bool isMenuActivated;
    public bool inventoryisactive {get ; private set; }

    [SerializeField] Button inventoryButton;
    [SerializeField] Button exitInventoryButton;

    private List<ItemData> collectedItems = new List<ItemData>();
    public static InventoryManager Instance {get ; private set; }
    //public InventorySystem inventorySystem;
    public ItemSlot[] itemSlot;


    public static InventoryManager GetInstance()
    {
        return Instance;
    }

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one InventoryManager in the scene.");
        }
        Instance = this;
    }
    void Start()
    {

    }

    void Update()
    {

        bool invButtonPressed = InputManager.GetInstance().GetInvButtonPressed();
        if(invButtonPressed && !isMenuActivated){
            PanelIsOn();
        }
        else if(invButtonPressed && isMenuActivated){
            PanelIsOff();
        }


    }


    public void PanelIsOn(){
        Time.timeScale = 0;
            InvPanel.SetActive(true);
            isMenuActivated = true;
            inventoryisactive = true;

            exitInventoryButton.gameObject.SetActive(true);
            inventoryButton.interactable = false;
        /* var playerInput= InputManager.GetInstance().GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap("UI"); */
    }

    public void PanelIsOff(){


        Time.timeScale = 1;
        InvPanel.SetActive(false);
        isMenuActivated = false;
        inventoryisactive = false;

        inventoryButton.interactable = true;
    }

    public void AddItem(ItemData item)
    {
       /*  if (!collectedItems.Contains(item))
        {
            collectedItems.Add(item); */
            Debug.Log($"Item added to inventory: {item.itemID}");

            for (int i = 0; i < itemSlot.Length; i++){
                if (itemSlot[i].isFull == false)
                {
                    itemSlot[i].AddItem(item);
                    return;

                }
            }
        }
        /* else
        {
            Debug.LogWarning("Item already in inventory.");
        } */
    //}
}
