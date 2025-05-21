using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkStoryManager : MonoBehaviour
{
    void Update()
    {
        // Dapatkan instance dari story yang sedang berjalan
        Story story = DialogueManager.GetInstance().GetStory();

        int berani = (int)story.variablesState["berani_berubah"];
        int rasional = (int)story.variablesState["rasional"];
        int terjebak = (int)story.variablesState["terjebak"];

        Debug.Log($"berani: {berani}, rasional: {rasional}, terjebak: {terjebak}");
        
        // Logika ending
        if (berani >= 2) {
            Debug.Log("Ending: Berani Berubah");
        }
        else if (rasional >= 2) {
            Debug.Log("Ending: Rasional");
        }
        else {
            Debug.Log("Ending: Terjebak");
        }
    }
    
}
