using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.UI;
using System;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System.Data;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;
    const string SPEAKER_TAG = "speaker";
    const string LAYOUT_TAG = "layout";
    const string PORTRAIT_TAG = "portrait";


    [Header ("Parameter")]
    [SerializeField] float typingSpeed = 0.05f;
    [Header ("Dialog UI")]
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private GameObject ikonLanjut;
    [SerializeField] private TextMeshProUGUI dialogTeks;
    [SerializeField] private TextMeshProUGUI displaynamaSpeaker;
    [SerializeField] private Animator portraitAnimator;

    private Animator layoutAnimator;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] Pilihan;
    private TextMeshProUGUI[] choicesText;



    // === Variable storeage === //
    


    private Story storynya;
    public bool dialogueisplaying {get ; private set; }

    private Coroutine tampilkanLineCoroutine;
    private bool canContinueToNextLine = false;

    private void Awake()
    {
        if (instance != null){
            Debug.LogWarning("Ditemukan lebih dari satu dialogmanager script");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        
        return instance;
    }

    private void Start()
    {
        dialogueisplaying = false;
        dialogPanel.SetActive(false);

        layoutAnimator = dialogPanel.GetComponent<Animator>();

        //untuk panjang choices text
        choicesText = new TextMeshProUGUI[Pilihan.Length];
        int index = 0;
        foreach (GameObject pilihannya in Pilihan){
            choicesText[index] = pilihannya.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if(!dialogueisplaying){
            return;
        }
        
        if ( canContinueToNextLine && storynya.currentChoices.Count == 0 && InputManager.GetInstance().GetNextDialoguePressed()){
            ContinueStory();
        }

        /* var playerInput= InputManager.GetInstance().GetComponent<PlayerInput>();
        playerInput.actions.FindActionMap("UI").Enable(); */

        int berani = (int)storynya.variablesState["berani_berubah"];
        int rasional = (int)storynya.variablesState["rasional"];
        int terjebak = (int)storynya.variablesState["terjebak"];

        if (berani >= 2) {
            Debug.Log("Ending: Berani Berubah");
            //Ending_beraniBerubah();
        }
        else if (rasional >= 2) {
            Debug.Log("Ending: Rasional");
            //Ending_rasional();
        }
        else if (terjebak >= 3) {
            Debug.Log("Ending: Terjebak");
            //Ending_terjebak();
            
        }
    }
    public Story GetStory() {
        return storynya;
    }

    public void EnterDialogueMode(TextAsset inkJSON, string knotToJump = null){
        storynya = new Story(inkJSON.text);
        if (!string.IsNullOrEmpty(knotToJump))
        {
            storynya.ChoosePathString(knotToJump);
        }
        dialogueisplaying = true;
        dialogPanel.SetActive(true);
        //dialogTeks.text = storynya.Continue();
        ContinueStory();
        
        

        var playerInput= InputManager.GetInstance().GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap("UI");
    }
    private IEnumerator ExitDialogueMode(){

        yield return new WaitForSeconds(0.2f);
        dialogueisplaying = false;
        dialogPanel.SetActive(false);
        dialogTeks.text = "";

        var playerInput = InputManager.GetInstance().GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap("Player");
        playerInput.actions.FindActionMap("UI").Enable();
        
    }

    private void ContinueStory(){
        if (storynya.canContinue){
            //set teks untuk dialog
            //mencegah bug dialogue line ketika line pertama belum selesai
            if (tampilkanLineCoroutine != null)
            {
                StopCoroutine(tampilkanLineCoroutine);
            }
            
            tampilkanLineCoroutine = StartCoroutine(TypewriterEffect(storynya.Continue()));
            //menampilkan pilihannya
            TampilkanPilihan();

            HandleTags(storynya.currentTags);
        }
        else{
            StartCoroutine(ExitDialogueMode());
        }
    }

    IEnumerator TypewriterEffect(string line)
    {
        dialogTeks.text = "";

        //hide ikon lanjut sebelum dialognya selesai
        ikonLanjut.SetActive(false);
        //hide tombol pilihan sebelum dialognya selesai
        HidePilihan();
        canContinueToNextLine = false;
        
        bool isMenambahkanEfekTag = false;
        foreach (char letter in line.ToCharArray())
        {
            //skip dialog ketika menekan tombol next dialog
            if (InputManager.GetInstance().GetNextDialoguePressed()){

                dialogTeks.text = line;
                break;
            }

            if (letter == '<' || isMenambahkanEfekTag)
            {
                isMenambahkanEfekTag = true;
                dialogTeks.text += letter;
                if (letter == '>'){
                    isMenambahkanEfekTag = false;
                }
            }
            else
            {
                dialogTeks.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
     
        }
        
        ikonLanjut.SetActive(true); //memunculkan kembali ikon lanjut
        TampilkanPilihan(); //memunculkan kembali tombol pilihan
        canContinueToNextLine = true;

    }

    void HidePilihan(){
        foreach (GameObject tombolPilihan in Pilihan){
            tombolPilihan.SetActive(false);
        }
    }

    void HandleTags(List<string> currentTags){
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split (":");
            if (splitTag.Length != 2){
                Debug.LogError("Tag tidak bisa diparse: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey){
                case SPEAKER_TAG:
                    displaynamaSpeaker.text = tagValue;
                    break;
                case LAYOUT_TAG:
                    layoutAnimator.Play(tagValue);
                    break;
                case PORTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    break;
                case "SCENE":
                    Debug.Log("Scene tag ditemukan: " + tagValue);
                    SceneLoader.Instance.FadeToScene(tagValue);
                    break;
                default:
                    Debug.LogWarning("Tagnya ada tapi tidak terhandle " + tag);
                    break;
            }
        }
    }

    void TampilkanPilihan(){
        List<Choice> currentChoices = storynya.currentChoices;

        if (currentChoices.Count > Pilihan.Length){
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " + currentChoices.Count);
        }

        int index = 0;
        foreach(Choice choice in currentChoices){
            Pilihan[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        for (int i = index; i < Pilihan.Length; i++){
            Pilihan[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());

    }

    IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(Pilihan[0].gameObject);
    }

    public void BuatPilihan(int choiceIndex){

        if (canContinueToNextLine)
        
        {
            storynya.ChooseChoiceIndex(choiceIndex);
            Debug.Log("Kamu memilih pilihan " + choicesText[choiceIndex].text);

            InputManager.GetInstance().RegisterNextDialogue();
            
            ContinueStory(); 

            
            Debug.Log("→ berani_berubah: " + storynya.variablesState["berani_berubah"]);
            Debug.Log("→ rasional: " + storynya.variablesState["rasional"]);
            Debug.Log("→ terjebak: " + storynya.variablesState["terjebak"]);
        }
        
    }

    void EndingCheck(){
        
    }
}
