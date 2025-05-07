using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    [Header("Visual Tag")]
    [SerializeField] GameObject visualtag;
    // Start is called before the first frame update
    bool PlayerInRange;

    [SerializeField] int sceneBuildIndex;
    private void Awake()
    {
        PlayerInRange = false;
        visualtag.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInRange){
            visualtag.SetActive(true);
            if (InputManager.GetInstance().GetInteractPressed())
            {
                
                SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
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
