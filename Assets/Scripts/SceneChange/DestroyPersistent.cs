using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPersistent : MonoBehaviour
{
    [SerializeField] private string[] targetScenes;

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        foreach (string scene in targetScenes)
        {
            if (currentScene == scene)
            {
                GameObject persistent = GameObject.Find("PERSISTENTGO(Clone)");
                if (persistent != null)
                {
                    Destroy(persistent);
                    Debug.Log("Destroyed PERSISTENT object in scene: " + currentScene);
                }
                break;
            }
        }
    }
}
