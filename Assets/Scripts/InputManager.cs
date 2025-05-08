using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{

    private bool interactPressed = false;
    private bool submitPressed = false;
    private bool leftClickPressed = false;
    private bool nextDialoguePressed = false;

    private bool invButtonPressed = false;

    private static InputManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }
        instance = this;
    }

    public static InputManager GetInstance() 
    {
        return instance;
    }

    public void InteractButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactPressed = true;
            Debug.Log("Interact button pressed");
        }
        else if (context.canceled)
        {
            interactPressed = false;
        } 
    }

    public void SubmitPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            submitPressed = true;
            Debug.Log ("Submit button pressed");
        }
        else if (context.canceled)
        {
            submitPressed = false;
        } 
    }
    public void NextDialoguePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            nextDialoguePressed = true;
            Debug.Log ("NeXtLINE button pressed");
        }
        else if (context.canceled)
        {
            nextDialoguePressed = false;
        } 
    }

    public void LeftClickPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            leftClickPressed = true;
            Debug.Log("Left mouse button clicked");
        }
         else if (context.canceled)
        {
            leftClickPressed = false;
        } 
    }

    public void InvButtonPressed(InputAction.CallbackContext context){
        if (context.performed)
        {
            invButtonPressed = true;
            Debug.Log ("Inventory button pressed");
        }
        else if (context.canceled)
        {
            invButtonPressed = false;
        } 
    }

    public void OnClick(InputAction.CallbackContext context){
        if (!context.started) return;
        
    }
    public bool GetInteractPressed() 
    {
        bool result = interactPressed;
        interactPressed = false;
        return result;
    }

    public bool GetSubmitPressed() 
    {
        bool result = submitPressed;
        submitPressed = false;
        return result;
    }
    public bool GetNextDialoguePressed()
    {
        bool result = nextDialoguePressed;
        nextDialoguePressed = false;
        return result;
    }

    public void RegisterNextDialogue(){
        nextDialoguePressed = false;
    }

    public void RegisterSubmitPressed() 
    {
        submitPressed = false;
    }

    public bool GetLeftClickPressed()
    {
        bool result = leftClickPressed;
        leftClickPressed = false;
        return result;
    }
    public void RegisterLeftClick(){
        leftClickPressed = false;
    }

    public bool GetInvButtonPressed(){
        bool result = invButtonPressed;
        invButtonPressed = false;
        return result;
    }
    public void RegisterInvButton(){
        invButtonPressed = false;
    }
}
