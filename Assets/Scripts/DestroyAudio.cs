using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyAudio : MonoBehaviour
{
    public AudioSource audioSource;
    //public AudioClip audioClip;
public string[] targetSceneNames; // List of target scenes where audio should be muted

    void Start()
    {
        // Register the sceneLoaded callback
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the current scene is in the target list
        foreach (string targetScene in targetSceneNames)
        {
            if (scene.name == targetScene)
            {
                // Mute the audio
                AudioSource audioSource = GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    //Destroy(audioSource.gameObject);
                    audioSource.mute = true; // Mute the audio
                }
                return; // Exit once a match is found
            }
        }

        // Unmute audio if not in target scenes
        AudioSource audioSourceToUnmute = GetComponent<AudioSource>();
        if (audioSourceToUnmute != null)
        {
            audioSourceToUnmute.mute = false; // Unmute the audio
        }
    }

    void OnDestroy()
    {
        // Unregister the callback when the object is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
