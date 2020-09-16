using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public int currentSlot;
    public int currentTotal;
    public Image SelectedItemIcon;

    public void Start()
    {
        SelectedItemIcon = GameObject.Find("SelectedItemIcon").GetComponent<Image>();
        SelectedItemIcon.enabled = false;

    }

    public void selectNextItem()
    {
        if (currentTotal > 1)
        {
            currentSlot += 1;

            // Set new index for current slot
            if (currentSlot == currentTotal)
            {
                currentSlot = 0;
            }

            // Switch SelectedItemIcon to new current image
            SelectedItemIcon.enabled = true;
            SelectedItemIcon.sprite = slots[currentSlot].transform.GetChild(0).gameObject.GetComponent<Image>().sprite;
           

        }
    }
}
