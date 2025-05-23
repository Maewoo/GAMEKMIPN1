using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Animations;
using UnityEngine.Events;

public class TriggerEventsPopupManager : MonoBehaviour
{
    [SerializeField] private string triggerName;
    public GameObject objectivePanel;
    public Animator panelAnimator;
    [SerializeField] string objectiveText;
    [SerializeField] TMP_Text text;


    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            objectivePanel.SetActive(true); // Make the panel visible
            panelAnimator.SetTrigger(triggerName); // Play the animation
            text.text = objectiveText;
        }
    }
}
