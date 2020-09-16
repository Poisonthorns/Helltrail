using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActionManager : MonoBehaviour
{

    var attackDelay = 1.0f;
    private float nextDamageEvent;
    private int attackPhase = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
 
    function Update()
    {
        if (Time.time >= nextDamageEvent)
        {
            nextDamageEvent = Time.time + attackDelay;
            //attack here
            switch (attackPhase)
            {
                case 0:
                    UnityEngine.Debug.Log("Attack phase 0");
                    //Start attack animation
                    attackPhase = 1;
                    break;
                case 1:
                    UnityEngine.Debug.Log("Attack phase 1");
                    //Call attack script here
                    attackPhase = 2;
                    break;
                case 2:
                    UnityEngine.Debug.Log("Attack phase 2");
                    //End attack animation here
                    attackPhase = 0;
                    break;
                default:
                    UnityEngine.Debug.Log("Something went wrong");
                    attackPhase = 0;
                    break;
            }
        }
    }
}
