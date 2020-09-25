using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public float lerpSpeed;
    public float startingHealth;
    public float maximumHealth;

    private Image content;
    private float currentFill;
    private float currentValue;

    [SerializeField]
    private AudioClip playerHurt;

    [SerializeField]
    private AudioClip playerHealed;

    private AudioSource playerAudio;


    // Start is called before the first frame update
    void Start()
    {
        content = GetComponent<Image>();
        currentValue = startingHealth;
        currentFill = currentValue / maximumHealth;
        playerAudio = GameObject.Find("Player").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        if (currentFill != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }
    }

    void GetInput()
	{
        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("O");
            LoseHealth(10);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P");
            GainHealth(10);
        }
    }

    public void LoseHealth(float amount)
	{
        playerAudio.PlayOneShot(playerHurt);
        currentValue -= amount;
        if(currentValue < 0)
            currentValue = 0;
        if (currentValue == 0)
            SceneManager.LoadScene("Death Screen");
        currentFill = currentValue / maximumHealth;
    }

    public void GainHealth(float amount)
	{
        playerAudio.PlayOneShot(playerHealed);
        currentValue += amount;
        if(currentValue > maximumHealth)
            currentValue = maximumHealth;
        currentFill = currentValue / maximumHealth;
    }
}
