using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;


public class ObjectManager : MonoBehaviour
{
    [Header ("Parameter")]
    [SerializeField] float typingSpeed = 0.05f;


    [Header ("Inspect UI")]
    [SerializeField] private GameObject inspectPanel;
    [SerializeField] private GameObject ItemImage;
    [SerializeField] private TextMeshProUGUI namaItem;
    [SerializeField] private TextMeshProUGUI deskripsiItem;

    [Header("CollectButton UI")]
    [SerializeField] private GameObject[] Pilihan;
    private TextMeshProUGUI[] choicesText;

    private Story objek_Ink;
    public bool dialogueisplaying {get ; private set; }

    private Coroutine tampilkanLineCoroutine;
    private bool canContinueToNextLine = false;

    private static ObjectManager instance;
    private void Awake()
    {
        if (instance != null){
            Debug.LogWarning("Ditemukan lebih dari satu dialogmanager script");
        }
        instance = this;
    }

    public static ObjectManager GetInstance()
    {
        
        return instance;
    }
    void Start()
    {
        dialogueisplaying = false;
        inspectPanel.SetActive(false);

        //untuk panjang choices text
        choicesText = new TextMeshProUGUI[Pilihan.Length];
        int index = 0;
        foreach (GameObject pilihannya in Pilihan){
            choicesText[index] = pilihannya.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    
    void Update()
    {
        if(!dialogueisplaying){
            return;
        }
        
        if (canContinueToNextLine && objek_Ink.currentChoices.Count == 0 && InputManager.GetInstance().GetNextDialoguePressed()){
            ContinueStory();
        }
    }

    

    public void EnterDialogueMode(TextAsset inkJSON){
        objek_Ink = new Story(inkJSON.text);

        //object interaction
        objek_Ink.BindExternalFunction("collect_item", (string itemID) => {CollectItem(itemID);});

        dialogueisplaying = true;
        inspectPanel.SetActive(true);
        //dialogTeks.text = storynya.Continue();
        ContinueStory();

        var playerInput= InputManager.GetInstance().GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap("UI");
    }
    private IEnumerator ExitDialogueMode(){

        yield return new WaitForSeconds(0.2f);
        dialogueisplaying = false;
        inspectPanel.SetActive(false);
        deskripsiItem.text = "";

        var playerInput = InputManager.GetInstance().GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap("Player");
    }

    private void ContinueStory(){
        if (objek_Ink.canContinue){
            //set teks untuk dialog

            if (tampilkanLineCoroutine != null)
            {
                StopCoroutine(tampilkanLineCoroutine);
            }

            string nextLine = objek_Ink.Continue();
            tampilkanLineCoroutine = StartCoroutine(TypewriterEffect(nextLine));
            //tampilkanLineCoroutine = StartCoroutine(TypewriterEffect(objek_Ink.Continue()));
            //deskripsiItem.text = objek_Ink.Continue();

            if (objek_Ink.currentTags != null)
            {
                foreach (string tag in objek_Ink.currentTags)
                {
                    if (tag.StartsWith("item_name"))
                    {
                        string itemName = tag.Substring("item_name: ".Length).Trim();
                        namaItem.text = itemName;
                    }
                }
            }

            //menampilkan pilihannya
            TampilkanPilihan();
        }
        else if (objek_Ink.currentChoices.Count == 0)
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    void CollectItem(string itemID){

        Debug.Log($"[ObjectManager] Collected item: {itemID}");

        /* InventoryManager inventory = FindObjectOfType<InventoryManager>();
        if(inventory != null)
        {
            inventory.AddItem(itemID);
        } */

        StartCoroutine(ExitDialogueMode());
    }

    void TampilkanPilihan(){
        List<Choice> currentChoices = objek_Ink.currentChoices;

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

    IEnumerator TypewriterEffect(string line)
    {
        deskripsiItem.text = "";

        //hide ikon lanjut sebelum dialognya selesai
        //ikonLanjut.SetActive(false);
        //hide tombol pilihan sebelum dialognya selesai
        HidePilihan();
        canContinueToNextLine = false;
        
        bool isMenambahkanEfekTag = false;
        foreach (char letter in line.ToCharArray())
        {
            //skip dialog ketika menekan tombol next dialog
            if (InputManager.GetInstance().GetNextDialoguePressed()){

                deskripsiItem.text = line;
                break;
            }

            if (letter == '<' || isMenambahkanEfekTag)
            {
                isMenambahkanEfekTag = true;
                deskripsiItem.text += letter;
                if (letter == '>'){
                    isMenambahkanEfekTag = false;
                }
            }
            else
            {
                deskripsiItem.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
     
        }
        
        //ikonLanjut.SetActive(true); //memunculkan kembali ikon lanjut
        TampilkanPilihan(); //memunculkan kembali tombol pilihan
        canContinueToNextLine = true;

    }

    void HidePilihan(){
        foreach (GameObject tombolPilihan in Pilihan){
            tombolPilihan.SetActive(false);
        }
    }

    IEnumerator SelectFirstChoice(){
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(Pilihan[0].gameObject);
    }

    public void BuatPilihan(int choiceIndex){

        if (canContinueToNextLine)
        {
            objek_Ink.ChooseChoiceIndex(choiceIndex);
            Debug.Log("Kamu memilih pilihan " + choicesText[choiceIndex].text);
            InputManager.GetInstance().RegisterNextDialogue();
            
            ContinueStory();
        }
         
    }


}
