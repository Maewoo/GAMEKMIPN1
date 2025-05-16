using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Tag")]
    [SerializeField] GameObject visualtag;

    [Header("Ink JSON")]
    [SerializeField] TextAsset inkJSON;

    bool PlayerInRange;

    public string knotToJump;

    //NEW INPUT SYSTEM
    /* private PlayerInputAction playerControls;
    private InputAction interact;
 */
    private void Awake()
    {
        PlayerInRange = false;
        visualtag.SetActive(false);
    }

    private void Start()
    {
        
    }

    void Update()
    {
        if (PlayerInRange && !DialogueManager.GetInstance().dialogueisplaying)
        {
            visualtag.SetActive(true);
            if (InputManager.GetInstance().GetInteractPressed())
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON, knotToJump);
            }
            //{
            //    //Debug.Log(inkJSON.text);
            //    
            //}
        }
        else
        {
            visualtag.SetActive(false);
        } 
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInRange = false;
        }
    }

}
