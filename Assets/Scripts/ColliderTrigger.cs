using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    [SerializeField]TriggerEventsPopupManager triggerEvent;

    /* void Start()
    {
        triggerEvent = triggerEvent.GetComponent<TriggerEventsPopupManager>();
    } */
    //private TriggerEventsPopupManager triggerEventsPopupManager;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            //TriggerEventsPopupManager.GetInstance().StartAnimationPopUp1();
            //triggerEvent.StartAnimationPopUp1();

            Destroy(gameObject);
        }
    }
}
