using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Transform attackPoint;

    int currentAttack;
    int attackDamage;
    float attackRange;

    [SerializeField]
    int lightAttackDamage = 10;
    [SerializeField]
    int heavyAttackDamage = 20;

    [SerializeField]
    float lightAttackRange = 0.2f;
    [SerializeField]
    float heavyAttackRange = 1.5f;

    [SerializeField]
    LayerMask enemyLayer;
    

    void Start()
	{
        attackDamage = lightAttackDamage;
        attackRange = lightAttackRange;
        currentAttack = 0;
	}

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void GetInput()
	{
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            SwapWeapon();
        }
    }

    void Attack()
	{
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        
        foreach(Collider2D enemy in enemies)
		{
            UnityEngine.Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
		}
	}

    void SwapWeapon()
	{
        switch(currentAttack)
		{
            case 0:
                currentAttack = 1;
                attackDamage = heavyAttackDamage;
                attackRange = heavyAttackRange;
                UnityEngine.Debug.Log("Switched to the heavy weapon");
                break;
            case 1:
                currentAttack = 0;
                attackDamage = lightAttackDamage;
                attackRange = lightAttackRange;
                UnityEngine.Debug.Log("Switched to the light weapon");
                break;
            default:
                UnityEngine.Debug.Log("Something went wrong in SwapWeapon");
                break;
		}
	}

    void OnDrawGizmosSelected()
	{
        if(attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
	}
}
