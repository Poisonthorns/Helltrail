using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public float startingHealth;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseHealth(float amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
            Death();
    }
    public void GainHealth(float amount)
    {
        currentHealth += amount;
        if (currentHealth <= 0)
            Death();
    }
    void Death()
    {
        //anim.Play("Imp_Death");
        //enemyNoises.PlayOneShot(enemyDeath, 1.0f);
        UnityEngine.Debug.Log(this.name + " died");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Destroy(gameObject);
    }
}
