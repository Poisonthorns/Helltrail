using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EnemyAttackManager : MonoBehaviour
{
    /* Attack Boolean Array size should be 2
     * Only set 1 as true!
     * 0 = Normal attack
     * 1 = No attack
     */
    public bool[] attackType;

    GameObject HealthBar;
    GameObject PlayerObject;
    public float attackRate = 3;
    private float timeSinceLastAttack;
    public float attackDamage;

    //animation
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        int numTrue = 0;
        foreach (bool i in attackType)
        {
            if (i)
            {
                numTrue++;
            }
        }
        Assert.IsTrue(numTrue == 1);

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
        if (attackType[0])
        {
            normalAttack();
        }
    }

    private void normalAttack()
	{
        PlayerObject = GameObject.Find("Player");

        float distance = Vector3.Distance(PlayerObject.transform.position, transform.position);
        if (distance <= 1.5f)
        {
            anim.Play("Attack");
            HealthBar = GameObject.Find("Player Health Bar");

            HealthBar.GetComponent<PlayerHealthController>().LoseHealth(attackDamage);
            /*
            //Delay
            StartCoroutine("waitForMelee", 0.2f);*/
            Debug.Log("attacking");
        }
    }
    /*
    IEnumerator waitForNormalAttack(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        if (distance <= 1.0f)
        {
            HealthBar.GetComponent<PlayerHealthController>().LoseHealth(attackDamage);
        }

        yield return null;
    }
    */
}


