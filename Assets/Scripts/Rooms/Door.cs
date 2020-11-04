using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public int direction;
    public bool isExit;
    GameObject roomManager;
    public static bool switchh = true;
    public static bool doorLock = false;
    void Start()
    {
        roomManager = GameObject.Find("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals("Player"))
        {
            if(switchh && !doorLock)
            {
                switchh = true;
                if(roomManager.GetComponent<LimboGeneration>()==null)
                {
                    roomManager.GetComponent<CircleCreation>().changeRooms(isExit);
                    
                }
                else
                {
                    roomManager.GetComponent<LimboGeneration>().changeRooms(isExit);
                    doorLock = true;
                }

            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals("Player"))
        {
            //print("yay");
            if (switchh)
            {
                switchh = false;
            }
            else
            {
                switchh = true;
            }
        }
    }
}
