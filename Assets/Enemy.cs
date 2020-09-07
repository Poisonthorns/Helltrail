using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
	{
        currentHealth -= damage;
        if(currentHealth <= 0)
            Death();

	}

    void Death()
	{
        UnityEngine.Debug.Log(this.name + " died");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
	}
}
