using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    
    public string spawnID;

    void Start()
    {
        if (SceneTransitionManager.Instance != null && 
            SceneTransitionManager.Instance.IDpintuyangdituju == spawnID)
        {
            string IDpintuyangdituju = SceneTransitionManager.Instance.IDpintuyangdituju;
            SpawnPoint[] spawnPoints = FindObjectsOfType<SpawnPoint>();
            foreach (var sp in spawnPoints)
            {
                if (sp.spawnID == IDpintuyangdituju)
                {
                    transform.position = sp.transform.position;
                    break;
                }
            }
        }
    }
    
}
