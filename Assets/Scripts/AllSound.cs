using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllSound : MonoBehaviour
{
    public static AllSound instance;
    public AudioClip[] clipnya;
    [SerializeField] List<AudioSource> suara = new List<AudioSource>();
    // Start is called before the first frame update

    void Awake(){
        instance = this;
    }
    void Start()
    {
        suara.Clear();
        for(int i = 0; i < clipnya.Length; i++){
            suara.Add(gameObject.AddComponent<AudioSource>());
            suara[i].clip = clipnya [i];
        }
    }

    public void panggil_suara(int i){
        suara[i].Play();
        Debug.Log("suara" + clipnya[i] + "dipanggil");
    }

    public void stop_suara(int i){
        suara[i].Stop();
    }
}
