using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
	public static Stats playerStats;

	public float upgradedDamage = 0.0f;
	public float upgradedSpeed = 0.0f;
	public float upgradedAttackRate = 0.0f;
	public int souls = 0;
	private static int MAX_SOULS_DISPLAYED = 10;
	private static int MAX_STAT_TOTAL = 100;
	public Image[] soulsCollected = new Image[MAX_SOULS_DISPLAYED];

	public Text currentDamage;
	public Text currentSpeed;
	public Text currentRate;

	Stat damageStatBar;
	Stat speedStatBar;
	Stat rateStatBar;

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
		souls = 0;
	}


	public void Start()
	{
		if (SceneManager.GetActiveScene().name == "StatScreen")
		{
			Debug.Log("Here");
			damageStatBar = GameObject.Find("Damage Bar").GetComponent<Stat>();
			speedStatBar = GameObject.Find("Speed Bar").GetComponent<Stat>();
			rateStatBar = GameObject.Find("Rate Bar").GetComponent<Stat>();

			currentDamage = GameObject.Find("Attack Damage Total Text").GetComponent<Text>();
			currentSpeed = GameObject.Find("Movement Speed Total Text").GetComponent<Text>();
			currentRate = GameObject.Find("Attack Rate Total Text").GetComponent<Text>();

			soulsCollected[0] = GameObject.Find("Soul").GetComponent<Image>();

			for(int index = 1; index < MAX_SOULS_DISPLAYED; index++)
            {
				soulsCollected[index] = GameObject.Find("Soul (" + index + ")").GetComponent<Image>(); ;
			}

			damageStatBar.Initialize(upgradedDamage, (float)MAX_STAT_TOTAL);
			speedStatBar.Initialize(upgradedSpeed, (float)MAX_STAT_TOTAL);
			rateStatBar.Initialize(upgradedAttackRate, (float)MAX_STAT_TOTAL);
			updateSoulDisplay(souls);
			updateTextDisplay(upgradedDamage, upgradedSpeed, upgradedAttackRate);

		}
	}

	void Update()
	{
		if (SceneManager.GetActiveScene().name == "StatScreen")
		{
			
			// Check for overflow of souls collected indicator
			if(souls > MAX_SOULS_DISPLAYED)
            {
				updateSoulDisplay(MAX_SOULS_DISPLAYED);
            }
            else
            {
				updateSoulDisplay(souls);
            }
		}
	}

	public void updateSoulDisplay(int numToDisplay)
    {
		// Make acquired souls visible
		for (int index = 0; index < numToDisplay; index++)
		{
			soulsCollected[index].color = new Color(soulsCollected[index].color.r, soulsCollected[index].color.g, soulsCollected[index].color.b, 1f);
		}

		// Make uncollected souls faded
		for (int index = numToDisplay; index < soulsCollected.Length; index++)
		{
			soulsCollected[index].color = new Color(soulsCollected[index].color.r, soulsCollected[index].color.g, soulsCollected[index].color.b, 0.2f);
		}
	}

	public void updateTextDisplay(float damage, float speed, float rate)
	{
		currentDamage.text = (int)damage + "/" + MAX_STAT_TOTAL;
		currentSpeed.text = (int)speed + "/" + MAX_STAT_TOTAL;
		currentRate.text = (int)rate + "/" + MAX_STAT_TOTAL;
	}

	public void upgradeDamage()
	{
		if(souls > 0 && upgradedDamage < MAX_STAT_TOTAL)
		{
			upgradedDamage += 5.0f;
			

			// Puts cap on the highest damage you can get
			if (upgradedDamage >= MAX_STAT_TOTAL)
			{
				upgradedDamage = 100.0f;
			}
			souls--;
			damageStatBar.Initialize(upgradedDamage, (float) MAX_STAT_TOTAL);
		}
		else
		{
			//Maybe a sound effect or something visual here
		}

		currentDamage.text = upgradedDamage + "/" + MAX_STAT_TOTAL;
	}

	public void upgradeSpeed()
	{
		if (souls > 0 && upgradedSpeed < MAX_STAT_TOTAL)
		{
			upgradedSpeed += 1.0f;
			// Puts cap on the highest speed you can get
			if (upgradedSpeed >= MAX_STAT_TOTAL)
			{
				upgradedSpeed = 100.0f;
			}
			souls--;
			speedStatBar.Initialize(upgradedSpeed, (float)MAX_STAT_TOTAL);
		}
		else
		{
			//Maybe a sound effect or something visual here
		}
		currentSpeed.text = upgradedSpeed + "/" + MAX_STAT_TOTAL;
	}

	public void upgradeAttackRate()
	{
		if (souls > 0 && upgradedAttackRate < MAX_STAT_TOTAL)
		{
			upgradedAttackRate += 0.25f;
			// Puts cap on the highest rate you can get
			if (upgradedAttackRate >= MAX_STAT_TOTAL)
			{
				upgradedAttackRate = 100.0f;
			}
			souls--;
			rateStatBar.Initialize(upgradedAttackRate, (float)MAX_STAT_TOTAL);
		}
		else
		{
			//Maybe a sound effect or something visual here
		}

		currentRate.text = upgradedAttackRate + "/" + MAX_STAT_TOTAL;
	}

	public void giveSouls(int num)
	{
		souls += num;
	}
}
