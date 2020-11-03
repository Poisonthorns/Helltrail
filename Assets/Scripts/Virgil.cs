using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virgil : MonoBehaviour
{
    public int stage =  -1;
    public Vector3 target;
    bool move = false;
    bool teleport = false;
    bool dialogue = false;
    bool arrivedAtTarget = false;
    bool changeRoom = false;
    
    public GameObject[] movePoints;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(14.5f, 14.5f, -2);
        target = transform.position;
        //next();
    }
    void Update()
    {
        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime);
            if(Vector3.Distance(transform.position, target) < 0.1)
            {
                move = false;
                arrivedAtTarget = true;
                if(changeRoom)
                {
                    changeRoom = false;
                    next();

                }
            }
        }
        else if(teleport)
        {
            transform.position = target;
            arrivedAtTarget = true;
            teleport = false;
            next();
        }
        else if(dialogue)
        {
            //doDialogue
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            print("enter pressed");
            next();
        }
    }
    void next()
    {
        ++stage;
        switch (stage)
        {
            case 0:
                {
                    move = true;
                    target = new Vector3(18.5f, 14.5f, -2);
                    arrivedAtTarget = false;
                    changeRoom = true;
                    //do Dialogue
                    break;
                }
            case 1:
                {

                    teleport = true;
                    target = new Vector3(25, 14.5f, -2);
                    break;
                }
            case 2:
                {
                    move = true;
                    target = new Vector3(30.5f, 14.5f, -2);
                    arrivedAtTarget = false;
                    break;
                }
            case 3:
                {
                    changeRoom = true;
                    move = true;
                    target = new Vector3(34.5f, 14.5f, -2);
                    arrivedAtTarget = false;
                    break;
                }
            case 4:
                {
                    teleport = true;
                    target = new Vector3(41.5f, 14.5f, -2);
                    break;
                }
            case 5:
                {
                    move = true;
                    target = new Vector3(46.5f, 14.5f, -2);
                    arrivedAtTarget = false;
                    break;
                }
            case 6:
                {
                    changeRoom = true;
                    move = true;
                    target = new Vector3(50.5f, 14.5f, -2);
                    arrivedAtTarget = false;
                    break;
                }
            case 7:
                {
                    teleport = true;
                    target = new Vector3(57.5f, 14.5f, -2);
                    break;
                }
            case 8:
                {
                    move = true;
                    target = new Vector3(62.5f, 14.5f, -2);
                    arrivedAtTarget = false;
                    break;
                }
            case 9:
                {
                    changeRoom = true;
                    move = true;
                    target = new Vector3(66.5f, 14.5f, -2);
                    arrivedAtTarget = false;
                    break;
                }
            case 10:
                {
                    teleport = true;
                    target = new Vector3(73.5f, 14.5f, -2);
                    break;
                }
            case 11:
                {
                    changeRoom = true;

                    move = true;
                    target = new Vector3(75.5f, 14.5f, -2);
                    arrivedAtTarget = false;
                    break;
                }
            case 12:
                {
                    changeRoom = true;
                    move = true;
                    target = new Vector3(75.5f, 11.5f, -2);
                    arrivedAtTarget = false;
                    break;
                }
            case 13:
                {
                    changeRoom = true;
                    move = true;
                    target = new Vector3(78.5f, 11.5f, -2);
                    arrivedAtTarget = false;
                    break;
                }
        }
    }
}
