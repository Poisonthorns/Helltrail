using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
	public LayerMask enemyLayer;
	public Transform attackPoint;
    public float additionalDamage;
	//Access variables like this: weapon.GetComponent<BaseWeapon>().attackDamage
	private GameObject weapon;
	int weaponIndex = 0;
	public GameObject[] allWeapons;
	public GameObject Arrow;

	private float timeSinceLastAttack;
	private AudioSource playerAudio;
	private WeaponWheel weaponSlots;

	[SerializeField]
	private AudioClip weaponSwap;

	//booleans here to know what weapon is currently equipped for animations along with animator
	public bool lightAttack = true;
	public bool heavyAttack = false;
	public Animator animUp;
	public Animator animDown;
	public Animator animRight;
	public Animator animLeft;
	public GameObject spriteUp;
	public GameObject spriteDown;
	public GameObject spriteRight;
	public GameObject spriteLeft;
	public bool attacking;
	public bool upAttack;
	public bool downAttack;
	public bool rightAttack;
	public bool leftAttack;

	public GameObject upgradedStats;

	// Start is called before the first frame update
	void Start()
	{
		weapon = allWeapons[weaponIndex];
		playerAudio = GameObject.Find("Player").GetComponent<AudioSource>();
		weaponSlots = GameObject.Find("Weapon Wheel").GetComponent<WeaponWheel>();

		lightAttack = true;
		heavyAttack = false;
	}

	// Update is called once per frame
	void Update()
	{
		GetInput();
	}

	private void GetInput()
	{
		//Swap Weapon Input
		if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftShift))
		{
			weaponIndex += 1;
			
			playerAudio.PlayOneShot(weaponSwap);

			if (weaponIndex >= allWeapons.Length)
			{
				weaponIndex = 0;
				weaponSlots.selectNext(allWeapons.Length - 1, 0);// light
											 //for light attack animation
				lightAttack = true;
				heavyAttack = false;
				weapon = allWeapons[weaponIndex];
			}
			else
			{
				weapon = allWeapons[weaponIndex];
				// This is hardcoded so I will fix this: swaps weapon icon on HUD
				if (weaponIndex == 1)
				{
					weaponSlots.selectNext(0, 1);// heavy
												 //for heavy attack animation
					lightAttack = false;
					heavyAttack = true;
				}
				else if (weaponIndex == 0)
				{
					weaponSlots.selectNext(1, 0);// light
												 //for light attack animation
					lightAttack = true;
					heavyAttack = false;
				}
				else if (weaponIndex == 2)
				{
					weaponSlots.selectNext(1, 2);// range
												 //for range attack animation
					lightAttack = false;
					heavyAttack = false;
				}
			}
			//Debug.Log("Swap weapon");
		}
		if(weapon.GetComponent<BaseWeapon>().rangedAttack)
		{
			if(Input.GetKeyDown(KeyCode.UpArrow))
			{
				Vector3 arrowPosition = new Vector3(0.0f, 1.0f, 0.0f);
				arrowPosition += transform.position;
				upAttack = true;
				downAttack = false;
				rightAttack = false;
				leftAttack = false;
				RangedAttack(225f, arrowPosition);
			}
			else if(Input.GetKeyDown(KeyCode.DownArrow))
			{
				Vector3 arrowPosition = new Vector3(0.0f, -1.0f, 0.0f);
				arrowPosition += transform.position;
				upAttack = false;
				downAttack = true;
				rightAttack = false;
				leftAttack = false;
				RangedAttack(45f, arrowPosition);
			}
			else if(Input.GetKeyDown(KeyCode.LeftArrow))
			{
				Vector3 arrowPosition = new Vector3(-1.0f, 0.0f, 0.0f);
				arrowPosition += transform.position;
				upAttack = false;
				downAttack = false;
				rightAttack = false;
				leftAttack = true;
				RangedAttack(-45f, arrowPosition);
			}
			else if(Input.GetKeyDown(KeyCode.RightArrow))
			{
				Vector3 arrowPosition = new Vector3(1.0f, 0.0f, 0.0f);
				arrowPosition += transform.position;
				upAttack = false;
				downAttack = false;
				rightAttack = true;
				leftAttack = false;
				RangedAttack(135f, arrowPosition);
			}
		}
		else
		{
			//Attack Input
			if(Input.GetKeyDown(KeyCode.UpArrow))
			{
				attackPoint.localPosition = new Vector3(0.0f, 1.5f, 0f);
				Debug.Log(weapon.GetComponent<BaseWeapon>().attackDamage);
				upAttack = true;
				downAttack = false;
				rightAttack = false;
				leftAttack = false;
				//Debug.Log(weapon.GetComponent<BaseWeapon>().attackDamage);

				/*
				//Animation
				spriteUp.SetActive(true);
				spriteDown.SetActive(false);
				spriteRight.SetActive(false);
				spriteLeft.SetActive(false);
				*/
				Attack();
			}
			else if(Input.GetKeyDown(KeyCode.DownArrow))
			{
				attackPoint.localPosition = new Vector3(0.0f, -1.5f, 0f);
				upAttack = false;
				downAttack = true;
				rightAttack = false;
				leftAttack = false;
				Attack();
			}
			else if(Input.GetKeyDown(KeyCode.LeftArrow))
			{
				attackPoint.localPosition = new Vector3(-1.0f, 0.5f, 0f);
				upAttack = false;
				downAttack = false;
				rightAttack = false;
				leftAttack = true;
				Attack();
			}
			else if(Input.GetKeyDown(KeyCode.RightArrow))
			{
				attackPoint.localPosition = new Vector3(1.0f, 0.5f, 0f);
				upAttack = false;
				downAttack = false;
				rightAttack = true;
				leftAttack = false;
				Attack();
			}
		}
	}

	void RangedAttack(float arrowRotation, Vector3 arrowPosition)
	{
		if (Time.time > timeSinceLastAttack)
		{
			timeSinceLastAttack = Time.time + weapon.GetComponent<BaseWeapon>().attackRate;

			//animation
			if(upAttack)
			{
				animUp.Play("Ranged Attack");
				spriteUp.SetActive(true);
				spriteDown.SetActive(false);
				spriteRight.SetActive(false);
				spriteLeft.SetActive(false);
				
				//Delay
				StartCoroutine(waitForRanged( 1.0f, arrowRotation, arrowPosition));
			}
			else if(downAttack)
			{
				animDown.Play("Ranged Attack");
				spriteUp.SetActive(false);
				spriteDown.SetActive(true);
				spriteRight.SetActive(false);
				spriteLeft.SetActive(false);
				
				//Delay
				StartCoroutine(waitForRanged( 1.0f, arrowRotation, arrowPosition));
			}
			else if(rightAttack)
			{
				animRight.Play("Ranged Attack");
				spriteUp.SetActive(false);
				spriteDown.SetActive(false);
				spriteRight.SetActive(true);
				spriteLeft.SetActive(false);
				
				//Delay
				StartCoroutine(waitForRanged( 1.0f, arrowRotation, arrowPosition));
			}
			else if(leftAttack)
			{
				animLeft.Play("Ranged Attack");
				spriteUp.SetActive(false);
				spriteDown.SetActive(false);
				spriteRight.SetActive(false);
				spriteLeft.SetActive(true);
				
				//Delay
				StartCoroutine(waitForRanged( 1.0f, arrowRotation, arrowPosition));
			}
		}
	}
	void Attack()
	{
		if (Time.time > timeSinceLastAttack)
		{
			timeSinceLastAttack = Time.time + weapon.GetComponent<BaseWeapon>().attackRate;
			//Debug.Log("PlayerCombatController Attack");
			//Animation for light attack here
			if(lightAttack && upAttack)
			{
				animUp.Play("Light Attack");
				spriteUp.SetActive(true);
				spriteDown.SetActive(false);
				spriteRight.SetActive(false);
				spriteLeft.SetActive(false);

				//Delay
				StartCoroutine("waitForMelee", 0.5f);
			}
			else if(lightAttack && downAttack)
			{
				animDown.Play("Light Attack");
				spriteUp.SetActive(false);
				spriteDown.SetActive(true);
				spriteRight.SetActive(false);
				spriteLeft.SetActive(false);

				//Delay
				StartCoroutine("waitForMelee", 0.5f);
			}
			else if(lightAttack && rightAttack)
			{
				animRight.Play("Light Attack");
				spriteUp.SetActive(false);
				spriteDown.SetActive(false);
				spriteRight.SetActive(true);
				spriteLeft.SetActive(false);

				//Delay
				StartCoroutine("waitForMelee", 0.5f);
			}
			else if(lightAttack && leftAttack)
			{
				animLeft.Play("Light Attack");
				spriteUp.SetActive(false);
				spriteDown.SetActive(false);
				spriteRight.SetActive(false);
				spriteLeft.SetActive(true);

				//Delay
				StartCoroutine("waitForMelee", 0.5f);
			}

			//Animation for heavy attack
			else if (heavyAttack && upAttack)
			{
				animUp.Play("Heavy Attack");
				spriteUp.SetActive(true);
				spriteDown.SetActive(false);
				spriteRight.SetActive(false);
				spriteLeft.SetActive(false);

				//Delay
				StartCoroutine("waitForMelee", 1.0f);
			}
			else if (heavyAttack && downAttack)
			{
				animDown.Play("Heavy Attack");
				spriteUp.SetActive(false);
				spriteDown.SetActive(true);
				spriteRight.SetActive(false);
				spriteLeft.SetActive(false);

				//Delay
				StartCoroutine("waitForMelee", 1.0f);
			}
			else if (heavyAttack && rightAttack)
			{
				animRight.Play("Heavy Attack");
				spriteUp.SetActive(false);
				spriteDown.SetActive(false);
				spriteRight.SetActive(true);
				spriteLeft.SetActive(false);

				//Delay
				StartCoroutine("waitForMelee", 1.0f);
			}
			else if (heavyAttack && leftAttack)
			{
				animLeft.Play("Heavy Attack");
				spriteUp.SetActive(false);
				spriteDown.SetActive(false);
				spriteRight.SetActive(false);
				spriteLeft.SetActive(true);

				//Delay
				StartCoroutine("waitForMelee", 1.0f);
			}
		}
	}

	IEnumerator waitForMelee(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);

		Collider2D[] enemies = Physics2D.OverlapBoxAll(attackPoint.position, weapon.GetComponent<BaseWeapon>().attackBox, 0f, enemyLayer, -100f, 100f);
		foreach (Collider2D enemy in enemies)
		{
			//UnityEngine.Debug.Log("We hit " + enemy.name);
			if (enemy.gameObject != null)
			{
				if (enemy.gameObject.tag == "Enemy" || enemy.gameObject.tag == "Boss")
				{
					playerAudio.PlayOneShot(weapon.GetComponent<BaseWeapon>().attackSound);

					enemy.GetComponent<EnemyHealthManager>().LoseHealth(weapon.GetComponent<BaseWeapon>().attackDamage + additionalDamage + upgradedStats.GetComponent<Stats>().upgradedAttackRate);
				}
			}
		}

		yield return null;
	}

	IEnumerator waitForRanged(float waitTime, float arrowRotation, Vector3 arrowPosition)
	{
		yield return new WaitForSeconds(waitTime);

		GameObject newArrow = Instantiate(Arrow, arrowPosition, Quaternion.Euler(0, 0, arrowRotation));
		newArrow.GetComponent<Arrow>().SetRotation(arrowRotation);
		newArrow.GetComponent<Arrow>().additionalDamage = additionalDamage;
		newArrow.GetComponent<Arrow>().upgradedStats = upgradedStats;

		yield return null;
	}
}
