using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInitializer : MonoBehaviour
{
     private void Awake()
    {
        if (GameObject.Find("PERSISTENTGO(Clone)") == null)
        {
            Debug.Log("Load Persist Game Object in scene: " + SceneManager.GetActiveScene().name);
            DontDestroyOnLoad(Instantiate(Resources.Load("PERSISTENTGO")));
        }
    }
}


