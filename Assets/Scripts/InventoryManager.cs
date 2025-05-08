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

    static InventoryManager instance;


    public static InventoryManager GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one InventoryManager in the scene.");
        }
        instance = this;
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
}
