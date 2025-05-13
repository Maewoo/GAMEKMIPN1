using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class SceneSwapper : MonoBehaviour
{
   public static SceneSwapper instance;
   static bool loadFromDoor;

   GameObject playerGO;
   Collider2D playerCollider;
   Collider2D doorCollider;
   Vector3 playerSpawnPosition;

   private DoorInteractionTrigger.DoorToSpawnAt doorToSpawnTo;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        playerGO = GameObject.FindGameObjectWithTag("Player");
        playerCollider = playerGO.GetComponent<Collider2D>();

    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public static void SwapSceneFromDoorUse(SceneField myScene, DoorInteractionTrigger.DoorToSpawnAt doorToSpawnAt){
        
        loadFromDoor = true;
        instance.StartCoroutine(instance.FadeOutThenChangeScene(myScene, doorToSpawnAt));
        Debug.Log ("Instancing the FadeOutThenchangeScene");
    }

    private IEnumerator FadeOutThenChangeScene(SceneField myScene, DoorInteractionTrigger.DoorToSpawnAt doorToSpawnAt = DoorInteractionTrigger.DoorToSpawnAt.None){

        SceneFadeManager.instance.StartFadeOut();

        while (SceneFadeManager.instance.IsFadingOut){
            yield return null;
        }

        //yield return null;
        Debug.Log ("Loading Scene");
        doorToSpawnTo = doorToSpawnAt;
        SceneManager.LoadScene(myScene);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        SceneFadeManager.instance.StartFadeIn();

        if (loadFromDoor){

            FindDoor(doorToSpawnTo);
            playerGO.transform.position = playerSpawnPosition;
            loadFromDoor = false;
        }
    }

    
    void FindDoor(DoorInteractionTrigger.DoorToSpawnAt doorSpawnNumber){
        DoorInteractionTrigger[] doors = FindObjectsOfType<DoorInteractionTrigger>();

        for (int i = 0; i < doors.Length; i++){
            if (doors[i].PosisiPintuIni == doorSpawnNumber){
                doorCollider = doors[i].gameObject.GetComponent<Collider2D>();

                CalculateSpawnPos();
                return;
            }
        }
    }

    void CalculateSpawnPos(){
        float colliderHeight = playerCollider.bounds.extents.y;
        playerSpawnPosition = doorCollider.transform.position - new Vector3(0f, colliderHeight, 0f);
    }
}
