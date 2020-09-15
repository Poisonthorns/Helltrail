using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    private AudioSource noises;
    public AudioClip itemAdded;

    public void Initialize()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        noises = gameObject.GetComponent<AudioSource>();
        Debug.Log(inventory);
    }

    // testing only
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    noises.PlayOneShot(itemAdded, 1.0f);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if(inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    noises.PlayOneShot(itemAdded, 1.0f);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
