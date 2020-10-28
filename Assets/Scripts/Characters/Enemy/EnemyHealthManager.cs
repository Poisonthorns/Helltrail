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

    // Damage particle effect
    public GameObject blood;

    // Health potion particle effect
    public GameObject healthUp;

    public GameObject soul;

    //aniamtion
    public Animator anim;

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
        Instantiate(blood, transform.position, Quaternion.identity);
        currentHealth -= amount;
        if(currentHealth <= 0)
            Death();
        currentFill = currentHealth / startingHealth;
    }
    public void GainHealth(float amount)
    {
        Instantiate(healthUp, transform.position, Quaternion.identity);
        currentHealth += amount;
        if (currentHealth <= 0)
            Death();
    }
    void Death()
    {
        anim.SetBool("Dead", true);
        //enemyNoises.PlayOneShot(enemyDeath, 1.0f);
        UnityEngine.Debug.Log(this.name + " died");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Instantiate(soul, transform.position, transform.rotation);
        Destroy(gameObject);

        // Win Condition for Satan
        if(gameObject.name.Equals("Satan"))
        {
            SceneManager.LoadScene("Win Screen");
        }
    }
}
