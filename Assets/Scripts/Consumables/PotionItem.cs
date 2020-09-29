using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionItem : MonoBehaviour
{
    public int id;
    Transform player;
    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        print("item detected");
        if (col.gameObject.name.Equals("Player"))
        {
            player = GameObject.Find("Player").transform;
            bool obtained = player.GetComponent<Inventory>().addItem(id);
            if(obtained)
            {
                Destroy(gameObject);
            }
        }
    }
}
