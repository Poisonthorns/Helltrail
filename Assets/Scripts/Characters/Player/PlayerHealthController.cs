using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public float lerpSpeed;
    public float startingHealth;
    public float maximumHealth;

    private Image content;
    private float currentFill;
    private float currentValue;

    // Start is called before the first frame update
    void Start()
    {
        content = GetComponent<Image>();
        currentValue = startingHealth;
        currentFill = currentValue / maximumHealth;
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
        currentValue -= amount;
        if(currentValue < 0)
            currentValue = 0;
        currentFill = currentValue / maximumHealth;
    }

    public void GainHealth(float amount)
	{
        currentValue += amount;
        if(currentValue > maximumHealth)
            currentValue = maximumHealth;
        currentFill = currentValue / maximumHealth;
    }
}
