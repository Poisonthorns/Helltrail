using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public int[] slots;
    public int currentSlot;
    public int currentTotal;
    public Image SelectedItemIcon;

    public void Start()
    {
        SelectedItemIcon = GameObject.Find("SelectedItemIcon").GetComponent<Image>();
        SelectedItemIcon.enabled = false;
        for(int i=0; i<slots.Length; ++i)
        {
            slots[i] = -1;
        }
    }
    public bool addItem(int itemID)
    {
        print(itemID);
        int nextIndex = getNextFreeSlot();
        if (getNextFreeSlot()==-1)
        {
            return false;
        }
        else
        {
            slots[nextIndex] = itemID;
        }
        return true;
    }
    void Update()
    {
        //change to switch statement later
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(useItem(1))
            {
                print("used item");
            }
            else
            {
                print("you can't use that item");
            }
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (useItem(2))
            {
                print("used item");
            }
            else
            {
                print("you can't use that item");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (useItem(3))
            {
                print("used item");
            }
            else
            {
                print("you can't use that item");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (useItem(4))
            {
                print("used item");
            }
            else
            {
                print("you can't use that item");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (useItem(5))
            {
                print("used item");
            }
            else
            {
                print("you can't use that item");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (useItem(6))
            {
                print("used item");
            }
            else
            {
                print("you can't use that item");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (useItem(7))
            {
                print("used item");
            }
            else
            {
                print("you can't use that item");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            if (useItem(8))
            {
                print("used item");
            }
            else
            {
                print("you can't use that item");
            }
        }
    }
    public bool useItem(int spot)
    {
        if (slots[spot-1] == -1)
        {
            return false;
        }
        else
        {
            GameObject.Find("Manager").GetComponent<PotionManager>().useItem(slots[spot-1]);
            slots[spot - 1] = -1;

            return true;
        }
    }
    int getNextFreeSlot()
    {
        for(int i=0; i<slots.Length; ++i)
        {
            if(slots[i] == -1)
            {
                return i;
            }
        }
        return -1;
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

            SelectedItemIcon.enabled = true;
           

        }
    }
}
