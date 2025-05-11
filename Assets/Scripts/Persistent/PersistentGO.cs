using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentGO : MonoBehaviour
{
    private static PersistentGO instance;

    void Awake()
    {
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else{
            Destroy(gameObject);
        }
    }
}
