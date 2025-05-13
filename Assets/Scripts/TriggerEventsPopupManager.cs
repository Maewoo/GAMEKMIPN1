using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Animations;
using UnityEngine.Events;

public class TriggerEventsPopupManager : MonoBehaviour
{

    public GameObject objectivePanel;
    public Animator panelAnimator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            objectivePanel.SetActive(true); // Make the panel visible
            panelAnimator.SetTrigger("showTutorial2"); // Play the animation
        }
    }
}
