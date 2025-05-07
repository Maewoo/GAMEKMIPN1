using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
using UnityEngine.InputSystem;

public class ItemExaminer : MonoBehaviour
{
    private static ItemExaminer instance;

    [SerializeField] private GameObject examineUI;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescText;
    [SerializeField] private Image itemImage;
    [SerializeField] private Button collectButton;

    

    /* [Header("Choices UI")]
    [SerializeField] private GameObject[] Pilihan;
    private TextMeshProUGUI[] choicesText; */

    private Story currentStory;
    private ItemData currentItem;
    private ObjectTrigger currentTrigger;
    public bool examineisplaying {get ; private set; }
    private void Awake()
    {
        if (instance != null){
            Debug.LogWarning("Ditemukan lebih dari satu dialogmanager script");
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
    public void ExamineItem(ItemData item, ObjectTrigger trigger)
    
    {
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

        examineUI.SetActive(true);
    }

    void CollectItem()
    {
        Debug.Log("Collected: " + currentItem.itemID);
        // Add item to inventory here
        
        currentItem = null;
        currentStory = null;
        examineUI.SetActive(false);
        examineisplaying = false;
        currentTrigger.Collect();

        var playerInput = InputManager.GetInstance().GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap("Player");

    }

}