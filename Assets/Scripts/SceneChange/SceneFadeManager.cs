using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneFadeManager : MonoBehaviour
{
    public static SceneFadeManager instance;

    [SerializeField] Image fadeOutImage;
    [Range  (0.1f, 10f), SerializeField] float fadeOutSpeed = 5f;
    [Range  (0.1f, 10f), SerializeField] float fadeInSpeed = 5f;

    [SerializeField] Color fadeOutStartColor;

    public bool IsFadingOut {get; private set;}
    public bool IsFadingIn {get; private set;}

    void Awake()
    {
        if (instance == null){
            instance = this;
        }

        fadeOutStartColor.a = 0f;

        /* Color c = fadeOutImage.color;
        c.a = 0f;
        fadeOutImage.color = c; */

    }

    void Update()
    {
        if (IsFadingOut){
             //if (fadeOutImage.color.a < 1f){
                fadeOutStartColor.a += Time.deltaTime * fadeOutSpeed;
                fadeOutImage.color = fadeOutStartColor;
                fadeOutStartColor.a = Mathf.Clamp01(fadeOutStartColor.a);
            //}
            if (fadeOutStartColor.a >= 1f)
            {
                IsFadingOut = false;
            }
        }
        /* else {
            IsFadingOut = false; */ 

            /* Color c = fadeOutImage.color;
            c.a += Time.deltaTime * fadeOutSpeed;
            c.a = Mathf.Clamp01(c.a);
            fadeOutImage.color = c;

            if (c.a >= 1f)
            {
                IsFadingOut = false;
            } */
        //}

        if (IsFadingIn){
            if (fadeOutImage.color.a > 0f){
                fadeOutStartColor.a -= Time.deltaTime * fadeInSpeed;

                fadeOutImage.color = fadeOutStartColor;
                fadeOutStartColor.a = Mathf.Clamp01(fadeOutStartColor.a);

                if (fadeOutStartColor.a >= 1f)
                {
                    IsFadingIn = false;
                }
            }
        }
        /* else {
            IsFadingIn = false;  */

           /* Color c = fadeOutImage.color;
            c.a -= Time.deltaTime * fadeInSpeed;
            c.a = Mathf.Clamp01(c.a);
            fadeOutImage.color = c;

            if (c.a <= 0f)
            {
                IsFadingIn = false;
            } */
        //}
    }

    public void StartFadeOut(){
        fadeOutImage.color = fadeOutStartColor;

        Debug.Log("Fading Out scene");
        IsFadingOut = true;

        IsFadingIn = false;

    }

    public void StartFadeIn(){

        if (fadeOutImage.color.a >= 1f){
            fadeOutImage.color = fadeOutStartColor;
        //if (fadeOutImage.color.a >= 1f) {
        Debug.Log ("Fading in scene...");
            IsFadingIn = true;

        IsFadingOut = false;
        //S}
        
        }
        
    }
}
