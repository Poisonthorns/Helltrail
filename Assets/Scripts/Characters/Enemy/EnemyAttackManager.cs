using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackManager : MonoBehaviour
{
    GameObject HealthBar;
    GameObject PlayerObject;
    public float attackRate = 3;
    private float timeSinceLastAttack;
    public float attackDamage;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GameObject.Find("Player Health Bar");
        PlayerObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
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
        if(distance <= 1.0f)
        {
            HealthBar.GetComponent<PlayerHealthController>().LoseHealth(attackDamage);
            Debug.Log("attacking");
        }
    }
}


