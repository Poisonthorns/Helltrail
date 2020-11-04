using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class EnemyHealthManager : MonoBehaviour
{
    /* Health Boolean Array size should be 2
     * Only set 1 as true!
     * 0 = Normal health
     * 1 = Infinite health
     */
    public bool[] healthType;

    public float startingHealth;
    private float currentHealth;

    public Image content;
    private float currentFill;
    public float lerpSpeed;

    // Damage particle effect
    public GameObject blood;

    // Blood puddle left after death
    public GameObject puddle;

    public GameObject soul;

    //aniamtion
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        int numTrue = 0;
        foreach (bool i in healthType)
        {
            if (i)
            {
                numTrue++;
            }
        }
        Assert.IsTrue(numTrue == 1);

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
        Instantiate(blood, transform.position, Quaternion.identity);

        if(healthType[0])
        {
            currentHealth -= amount;
        }

        if(currentHealth <= 0)
        {
            Death();
        }
        Debug.Log(currentHealth);
        currentFill = currentHealth / startingHealth;
    }
    public void GainHealth(float amount)
    {
        currentHealth += amount;
        if (currentHealth <= 0)
            Death();
    }

    
    public void PlayParticle(GameObject particle)
    {
      Instantiate(particle, transform.position, Quaternion.identity);
    }
    

    void Death()
    {
        anim.SetBool("Dead", true);
        //enemyNoises.PlayOneShot(enemyDeath, 1.0f);
        UnityEngine.Debug.Log(this.name + " died");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        GameObject puddleObj = Instantiate(puddle, transform.position, Quaternion.identity);
        puddleObj.transform.localScale = new Vector3(Random.Range(0.2f, 0.25f), Random.Range(0.2f, 0.25f), 1.0f);
        Instantiate(soul, transform.position, transform.rotation);
        Destroy(gameObject);

        // Win Condition for Satan
        if(gameObject.name.Equals("Hoggish"))
        {
            SceneManager.LoadScene("Win Screen");
        }
    }
}
