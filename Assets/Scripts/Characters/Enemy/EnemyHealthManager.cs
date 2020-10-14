using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    public float startingHealth;
    private float currentHealth;

    public Image content;
    private float currentFill;
    public float lerpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        currentFill = currentHealth / startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFill != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }
    }

    public void LoseHealth(float amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
            Death();
        currentFill = currentHealth / startingHealth;
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
