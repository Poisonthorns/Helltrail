using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionItem : MonoBehaviour
{
    public GameObject effect;
    private Transform player;
    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    public void Use()
    {
        // Do effect here
        //Instantiate(effect, player.position, Quaternion.identity);
        // Remove selector image here
        player.GetComponent<Inventory>().currentTotal -= 1;
        Destroy(gameObject);
    }
}
