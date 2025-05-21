using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;
    [SerializeField] private Image fadeOverlay;
    [SerializeField] private float fadeDuration = 1f;

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeAndLoad(sceneName));
    }

    IEnumerator FadeAndLoad(string sceneName)
    {
        yield return StartCoroutine(Fade(1)); // fade out
        SceneManager.LoadScene(sceneName);
        yield return new WaitForSeconds(0.1f); // kecil delay untuk load
        yield return StartCoroutine(Fade(0)); // fade in
    }

    IEnumerator Fade(float targetAlpha)
    {
        fadeOverlay.raycastTarget = true;
        Color color = fadeOverlay.color;
        float startAlpha = color.a;
        float timer = 0f;

        while (timer < fadeDuration)
        {
            float t = timer / fadeDuration;
            color.a = Mathf.Lerp(startAlpha, targetAlpha, t);
            fadeOverlay.color = color;
            timer += Time.deltaTime;
            yield return null;
        }

        color.a = targetAlpha;
        fadeOverlay.color = color;
        fadeOverlay.raycastTarget = targetAlpha == 1;
    }
}
