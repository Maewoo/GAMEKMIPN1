using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartNewScene : MonoBehaviour
{
    public Animator animator;
    [SerializeField] string AnimationName;
    public UnityEvent onSceneLoaded;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        onSceneLoaded?.Invoke(); // Trigger UnityEvent
    }

    public void PlayAnimation()
    {
        //if(animator != null && string.IsNullOrEmpty (AnimationName))
        animator.SetTrigger(AnimationName);
    }

}
