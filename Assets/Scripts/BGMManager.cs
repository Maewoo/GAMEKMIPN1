using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance;
    public AudioSource audioSource;
    public AudioClip[] bgmClips;

    private string currentSceneName = "";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject); // Avoid duplicates
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != currentSceneName)
        {
            currentSceneName = scene.name;
            PlayBGMForScene(scene.name);
        }
    }

    void PlayBGMForScene(string sceneName)
    {
        AudioClip clipToPlay = null;

        switch (sceneName)
        {
            case "kamartidur":
                clipToPlay = bgmClips[0];
                break;
            case "ruangKelas":
                clipToPlay = bgmClips[1];
                break;
            case "kamartidur2":
                clipToPlay = bgmClips[2];
                break;
            case "kamartidur3":
                clipToPlay = bgmClips[2];
                break;
            case "ruangKelas2":
                clipToPlay = bgmClips[1];
                break;
            case "ruangTV2":
                clipToPlay = bgmClips[3];
                break;
            default:
                clipToPlay = null;
                break;
        }

        if (clipToPlay != null && audioSource.clip != clipToPlay)
        {
            audioSource.clip = clipToPlay;
            audioSource.Play();
        }
    }
}
