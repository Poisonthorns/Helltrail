using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActionManager : MonoBehaviour
{

    float attackDelay = 1.0f;
    private float nextDamageEvent;
    private int attackPhase = 0;
    CastSpell spell = null;
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        spell = this.gameObject.GetComponent<CastSpell>();
        gameObject.GetComponent<CastSpell>().iceSpell();
        if(spell==null)
        {
            print("wtf");
        }
    }
 
    void Update()
    {
        /*
        if (counter == 6000)
        {
            spell.iceSpell();
        }
        else
        {
            ++counter;
        }*/
        if (Time.time >= nextDamageEvent)
        {
            nextDamageEvent = Time.time + attackDelay;

            //attack here
            switch (attackPhase)
            {
                case 0:

                    UnityEngine.Debug.Log("Attack phase 0");
                    spell.iceSpell();
                    attackPhase = 1;
                    break;
                case 1:
                    UnityEngine.Debug.Log("Attack phase 1");
                    //Call attack script here
                    spell.fireBallSpell();
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
