using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class DoorInteractionTrigger : MonoBehaviour
{
    [Header ("Spawn KE")]
    [SerializeField] DoorToSpawnAt DoorToSpawnTo;
    [SerializeField] SceneField scenetoload;

    [Header("Visual Tag")]
    [SerializeField] GameObject visualtag;
    bool PlayerInRange;

    [Space(10f)]
    [Header ("Pintu Ini")]
    public DoorToSpawnAt PosisiPintuIni;

    public enum DoorToSpawnAt{
        None,
        One,
        Two,
        Three,
        Four,
    }
    private void Awake()
        {
            PlayerInRange = false;
            visualtag.SetActive(false);
        }
    void Update()
    {
        if (PlayerInRange){
            visualtag.SetActive(true);
            if (InputManager.GetInstance().GetInteractPressed())
            {
                SceneSwapper.SwapSceneFromDoorUse(scenetoload, DoorToSpawnTo);
            }
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
