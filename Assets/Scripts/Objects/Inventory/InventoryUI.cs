using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
     public InventorySystem inventory;
    public Transform slotParent;
    public GameObject slotPrefab;

    private void Start()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        foreach (Transform child in slotParent)
        {
            Destroy(child.gameObject);
        }

        foreach (var slot in inventory.slots)
        {
            GameObject slotGO = Instantiate(slotPrefab, slotParent);
            Image icon = slotGO.transform.Find("Icon").GetComponent<Image>();
            TextMeshProUGUI quantityText = slotGO.transform.Find("Quantity").GetComponent<TextMeshProUGUI>();

            if (!slot.IsEmpty)
            {
                icon.sprite = slot.item.image;
                icon.enabled = true;
                quantityText.text = slot.quantity > 1 ? slot.quantity.ToString() : "";
            }
            else
            {
                icon.enabled = false;
                quantityText.text = "";
            }
        }
    }
}
