using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackManager : MonoBehaviour
{
    GameObject HealthBarObject;
    GameObject PlayerObject;
    public float attackRate = 3;
    private float timeSinceLastAttack;
    public float attackDamage;

    // Start is called before the first frame update
    void Start()
    {
        HealthBarObject = GameObject.Find("Health Bar");
        PlayerObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("update");
        //whenever the character is attacking...
        if (Time.time > timeSinceLastAttack)
        {
            Attack();
            timeSinceLastAttack = Time.time + attackRate;
        }
    }

    void Attack()
	{
        float distance = Vector3.Distance(PlayerObject.transform.position, transform.position);
        if(distance <= 1.2f)
        {
            HealthBarObject.GetComponent<PlayerHealthController>().LoseHealth(attackDamage);
            Debug.Log("attacking");
        }
    }
}


