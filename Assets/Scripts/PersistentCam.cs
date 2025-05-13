using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentCam : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
}

