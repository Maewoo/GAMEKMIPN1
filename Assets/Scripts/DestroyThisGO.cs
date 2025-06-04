using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThisGO : MonoBehaviour
{
    public static DestroyThisGO instance;
    void Awake()
    {
        /* GameObject[] bgms = GameObject.FindGameObjectsWithTag("BGM");

        // If another BGM exists and it's not this one, destroy the other
        foreach (GameObject bgm in bgms)
        {
            if (bgm != this.gameObject)
            {
                Destroy(this.gameObject);
                //return;
            }
        } */

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        /* else{
            Destroy(this.gameObject);
        } */
    }
}
