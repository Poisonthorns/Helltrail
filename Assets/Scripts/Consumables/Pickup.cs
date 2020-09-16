using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    private AudioSource noises;
    public AudioClip itemAdded;

    public void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        noises = gameObject.GetComponent<AudioSource>();

    }

    // testing only
    public void Update()
    {
        Debug.Log(inventory + "it knows the inventory");
    }

    //private void OnTriggerEnter2D(Collider2D other)
    public void addItem()
    {
        
       // if(other.CompareTag("Player"))
       // {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if(inventory.isFull[i] == false)
                {
                    
                    inventory.isFull[i] = true;
                    inventory.currentTotal += 1;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    // First time adding an item displays its sprite automatically
                    if (inventory.currentTotal == 1 && inventory.currentSlot == 0)
                    {
                        inventory.SelectedItemIcon.sprite = inventory.slots[inventory.currentSlot].transform.GetChild(0).gameObject.GetComponent<Image>().sprite;
                        inventory.SelectedItemIcon.enabled = true;
                    }
                    noises.PlayOneShot(itemAdded, 1.0f);
                    Destroy(gameObject);
                    break;
                }
            }
       // }
    }
}
