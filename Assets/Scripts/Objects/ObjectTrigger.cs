using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectTrigger : MonoBehaviour
{

    [Header("Visual Tag")]
    [SerializeField] GameObject visualtag;

    /* [Header("Ink JSON")]
    [SerializeField] TextAsset inkJSON; */

    //public enum InteractionType {NONE, PickUp, Examine}
    //public InteractionType type;
    bool PlayerInRange;

    private ItemExaminer examiner;
    //[SerializeField] private ItemData itemData; 
    

    private void Awake()
    {
        PlayerInRange = false;
        visualtag.SetActive(false);
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (PlayerInRange && !ItemExaminer.GetInstance().examineisplaying)
        {
            visualtag.SetActive(true);
            if (InputManager.GetInstance().GetInteractPressed())
            {
                //ObjectManager.GetInstance().EnterDialogueMode(inkJSON);
                //examiner.ExamineItem(itemData, this);
                examiner = ItemExaminer.GetInstance().gameObject.GetComponent<ItemExaminer>();
                examiner.ExamineItem(this.gameObject, this);
            }
        }
        else
        {
            visualtag.SetActive(false);
        }
    }

    /* public void Interact(){
        switch (type){
            case InteractionType.PickUp:
                Debug.Log ("Pick Up");
                break;

        }
    } */

    public void Collect()
    {
        //this.transform.parent.gameObject.SetActive(false);
        Destroy(this.gameObject);
        
    }
    /* void OnInteractWithItem(ItemData item)
    {
        examiner.ExamineItem(item, this);
    } */

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
