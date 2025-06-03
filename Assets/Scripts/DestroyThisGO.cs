using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThisGO : MonoBehaviour
{
    public static DestroyThisGO instance;
    void Awake()
    {
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        /* else{
            Destroy(this.gameObject);
        } */
    }
}
