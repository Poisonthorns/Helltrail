using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
	public static Stats playerStats;

	public float upgradedDamage = 0.0f;
	public float upgradedSpeed = 0.0f;
	public float upgradedAttackRate = 0.0f;
	public int souls = 3;

	public Text soulsLeft;

	void Awake()
	{
		if(playerStats != null)
		{
			GameObject.Destroy(playerStats);
		}
		else
		{
			playerStats = this;
		}

		DontDestroyOnLoad(this);	
	}

	void OnApplicationQuit()
	{
		upgradedDamage = 0.0f;
		upgradedSpeed = 0.0f;
		upgradedAttackRate = 0.0f;
		souls = 3;
	}


	void OnStart()
	{
		if (SceneManager.GetActiveScene().name == "StatScreen")
		{
			Debug.Log("Here");
			soulsLeft = GameObject.Find("Souls Left").GetComponent<Text>();
			updateSoulsText();
		}
	}

	void Update()
	{
		if (SceneManager.GetActiveScene().name == "StatScreen")
		{
			soulsLeft.text = "Souls Left: " + souls;
		}
	}

	public void upgradeDamage()
	{
		if(souls > 0)
		{
			upgradedDamage += 5.0f;
			souls--;
		}
		else
		{
			//Maybe a sound effect or something visual here
		}
		updateSoulsText();
	}

	public void upgradeSpeed()
	{
		if (souls > 0)
		{
			upgradedSpeed += 1.0f;
			souls--;
		}
		else
		{
			//Maybe a sound effect or something visual here
		}
		updateSoulsText();
	}

	public void upgradeAttackRate()
	{
		if (souls > 0)
		{
			upgradedAttackRate += 0.2f;
			souls--;
		}
		else
		{
			//Maybe a sound effect or something visual here
		}
		updateSoulsText();
	}

	void updateSoulsText()
	{
		if (SceneManager.GetActiveScene().name == "StatScreen")
		{
			if (soulsLeft != null)
			{
				soulsLeft.text = "Souls left: " + souls;
			}
			else
			{
				soulsLeft = GameObject.Find("Souls Left").GetComponent<Text>();
				updateSoulsText();
			}
		}
	}

	public void giveSouls(int num)
	{
		souls += num;
	}
}
