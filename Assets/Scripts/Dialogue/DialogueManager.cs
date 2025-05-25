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
    const string SCENE_TAG = "scene";
    const string UI_ANIM = "UI_Anim";
    const string CHECKENDING_TAG = "checkdominantending";


    [Header("Parameter")]
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

    [Header("UI ANIM")]
    [SerializeField] private Animator uiAnimator;

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
        foreach (GameObject pilihannya in Pilihan)
        {
            choicesText[index] = pilihannya.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    
    }

    private void Update()
    {
        if (!dialogueisplaying)
        {
            return;
        }

        if (canContinueToNextLine && storynya.currentChoices.Count == 0 && InputManager.GetInstance().GetNextDialoguePressed())
        {
            ContinueStory();
        }

        /* var playerInput= InputManager.GetInstance().GetComponent<PlayerInput>();
        playerInput.actions.FindActionMap("UI").Enable(); */
        
    }
    public Story GetStory() {
        return storynya;
    }

    public void EnterDialogueMode(TextAsset inkJSON, string knotToJump = null){
        storynya = new Story(inkJSON.text);
        
        GlobalEndingState.ApplyToStory(storynya);

        if (!string.IsNullOrEmpty(knotToJump))
        {

            /* if (PlayerPrefs.HasKey("SavedInkState"))
            {
                string savedState = PlayerPrefs.GetString("SavedInkState");
                storynya.state.LoadJson(savedState);
            } */

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
        
        /* string savedState = storynya.state.ToJson();
        PlayerPrefs.SetString("SavedInkState", savedState); */

        yield return new WaitForSeconds(0.2f);
        dialogueisplaying = false;
        dialogPanel.SetActive(false);
        dialogTeks.text = "";

        var playerInput = InputManager.GetInstance().GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap("Player");
        playerInput.actions.FindActionMap("UI").Enable();
        
    }

    private void ContinueStory(){
        //GlobalEndingState.CekEndingDominan(storynya);

        if (storynya.canContinue)
        {
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

            GlobalEndingState.UpdateFromStory(storynya);

            Debug.Log("→ berani_berubah: " + storynya.variablesState["berani_berubah"]);
            Debug.Log("→ rasional: " + storynya.variablesState["rasional"]);
            Debug.Log("→ terjebak: " + storynya.variablesState["terjebak"]);

        }
        else
        {
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
            if (tag.Contains(":"))
            {
                string[] splitTag = tag.Split(":");
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag tidak bisa diparse: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    displaynamaSpeaker.text = tagValue;
                    break;
                case LAYOUT_TAG:
                    layoutAnimator.Play(tagValue);
                    break;
                case PORTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    break;
                case SCENE_TAG:
                    Debug.Log("Scene tag ditemukan: " + tagValue);
                    SceneLoader.Instance.FadeToScene(tagValue);
                    break;

                /* case CHECKENDING_TAG:
                    GlobalEndingState.CekEndingDominan(storynya);
                    break; */

                case UI_ANIM:
                    string[] uiData = tagValue.Split(',');
                    if (uiData.Length == 2)
                    {
                        string uiName = uiData[0].Trim();
                        string triggerName = uiData[1].Trim();

                        Debug.Log($"Mencoba trigger UI: {uiName}, anim: {triggerName}");

                        GameObject uiObject = GameObject.Find(uiName);
                        Animator anim = uiObject?.GetComponent<Animator>();

                        if (anim != null)
                        {
                            anim.SetTrigger(triggerName);
                            Debug.Log($"Trigger UI animasi '{triggerName}' pada {uiName}");
                        }
                        else
                        {
                            Debug.LogWarning($"Animator tidak ditemukan di {uiName}");
                        }

                    }
                    else
                    {
                        Debug.LogError("Format tag UI_ANIM salah: " + tagValue);
                    }
                    break;
                default:
                    Debug.LogWarning("Tagnya ada tapi tidak terhandle " + tag);
                    break;
                }
            }
            else
            {
                switch (tag.Trim())
                {
                    case "checkdominantending":
                        GlobalEndingState.CekEndingDominan(storynya);

                        if (storynya.canContinue)
                        {
                            ContinueStory();
                        }
                        break;

                    default:
                        Debug.Log("Tag tunggal tidak dikenali: " + tag);
                        break;
                }
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
            
        }
        
    }

    void EndingCheck(){

        int berani = (int)storynya.variablesState["berani_berubah"];
        int rasional = (int)storynya.variablesState["rasional"];
        int terjebak = (int)storynya.variablesState["terjebak"];

        if (berani >= 4)
        {
            Debug.Log("Ending: Berani Berubah");
            //Ending_beraniBerubah();
        }
        else if (rasional >= 4)
        {
            Debug.Log("Ending: Rasional");
            //Ending_rasional();
        }
        else if (terjebak >= 3)
        {
            Debug.Log("Ending: Terjebak");
            //Ending_terjebak();

        }
    }
}

public static class GlobalEndingState
{
    public static int berani_berubah = 0;
    public static int rasional = 0;
    public static int terjebak = 0;

    public static void UpdateFromStory(Story story)
    {
        berani_berubah = (int)story.variablesState["berani_berubah"];
        rasional = (int)story.variablesState["rasional"];
        terjebak = (int)story.variablesState["terjebak"];
    }

    public static void ApplyToStory(Story story)
    {
        story.variablesState["berani_berubah"] = berani_berubah;
        story.variablesState["rasional"] = rasional;
        story.variablesState["terjebak"] = terjebak;
    }

    public static void Reset()
    {
        berani_berubah = 0;
        rasional = 0;
        terjebak = 0;
    }

    public static void CekEndingDominan(Story story)
    {
        int berani = (int)story.variablesState["berani_berubah"];
        int rasional = (int)story.variablesState["rasional"];
        int terjebak = (int)story.variablesState["terjebak"];

        Debug.Log($"→ berani: {berani}, rasional: {rasional}, terjebak: {terjebak}");

        if (berani > rasional && berani > terjebak)
        {
            story.ChoosePathString("berani_ending");
            Debug.Log("Ending: BERANI");
        }
        else if (rasional > berani && rasional > terjebak)
        {
            story.ChoosePathString("rasional_ending");
            Debug.Log("Ending: RASIONAL");
        }
        else if (terjebak > berani && terjebak > rasional)
        {
            story.ChoosePathString("terjebak_ending");
            Debug.Log("Ending: TERJEBAK");

        }
    }
}
/* public static class EndingCheckerDominan
{
    public Story story;

    public static void CekEndingDominan(Story storynya)
    {
        int berani = (int)story.variablesState["berani_berubah"];
        int rasional = (int)story.variablesState["rasional"];
        int terjebak = (int)story.variablesState["terjebak"];

        Debug.Log($"→ berani: {berani}, rasional: {rasional}, terjebak: {terjebak}");

        if (berani > rasional && berani > terjebak)
        {
            story.ChoosePathString("berani_ending");
            Debug.Log("Ending: BERANI");
        }
        else if (rasional > berani && rasional > terjebak)
        {
            story.ChoosePathString("rasional_ending");
            Debug.Log("Ending: RASIONAL");
        }
        else if (terjebak > berani && terjebak > rasional)
        {
            story.ChoosePathString("terjebak_ending");
            Debug.Log("Ending: TERJEBAK");

        }
    }
} */