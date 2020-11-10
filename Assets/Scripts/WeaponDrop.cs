using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDrop : MonoBehaviour
{
    public GameObject weapon;
    Transform temp;
    public int weaponID;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            if (weaponID == 1)
            {
                collision.gameObject.GetComponent<PlayerCombatController>().noSword = false;
            }
            else
            {
                collision.gameObject.GetComponent<PlayerCombatController>().noBow = false;
            }
            Destroy(gameObject);
        }

    }
}
