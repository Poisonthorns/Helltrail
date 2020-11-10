using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementController : MonoBehaviour
{
	public float speed;
	public Transform movePoint;
	public LayerMask collideables;
	//Need animator here for animations
	public Animator animUp;
	public Animator animDown;
	public Animator animRight;
	public Animator animLeft;

	public GameObject upgradedStats;

	//Turning Animations
	public GameObject spriteUp;
	public GameObject spriteDown;
	public GameObject spriteRight;
	public GameObject spriteLeft;
	public bool attacking;

	public float upgradedSpeed;
	// Start is called before the first frame update
	void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
		upgradedSpeed = upgradedStats.GetComponent<Stats>().upgradedAttackRate;
		transform.position = Vector3.MoveTowards(transform.position, movePoint.position, (speed + upgradedStats.GetComponent<Stats>().upgradedSpeed) * Time.deltaTime);
        GetInput();
    }

	private void GetInput()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
        {
			SceneLoader.GoToDebug();
        }

		if (Input.GetKeyDown(KeyCode.Backspace))
		{
           SceneLoader.GoToPause();
		}

		/*
		
		if(Input.GetKeyDown(KeyCode.I))
		{
			GameObject potion1 = GameObject.Find("Potion");
			GameObject potion2 = GameObject.Find("Potion (1)");
			if(potion1 != null)
			{
				potion1.GetComponent<Pickup>().addItem();
			}
			else if(potion2 != null)
			{
				potion2.GetComponent<Pickup>().addItem();
			}
		}
		if(Input.GetKeyDown(KeyCode.U))
		{
			GetComponent<Inventory>().selectNextItem();
		}
		*/


		//Movement Input
		if (Vector3.Distance(transform.position, movePoint.position) <= 0.02f)
		{
			if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
			{
				//Movement animation here (this handles both up and down, you'll need to check which is happening)
				animDown.SetBool("Walking", true);
				animUp.SetBool("Walking", true);
				if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 1f), .2f, collideables))
				{
					movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);

					//Up and Down Animations
					if(Input.GetKey(KeyCode.W) && !attacking) 
					{
						spriteUp.SetActive(true);
						spriteDown.SetActive(false);
						spriteRight.SetActive(false);
						spriteLeft.SetActive(false);
					}
					else if (Input.GetKey(KeyCode.S) && !attacking)
					{
						spriteUp.SetActive(false);
						spriteDown.SetActive(true);
						spriteRight.SetActive(false);
						spriteLeft.SetActive(false);
					}
				}
			}
			else if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
			{
				animRight.SetBool("Walking", true);
				animLeft.SetBool("Walking", true);
				if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 1f), .2f, collideables))
				{
					//Movement animation here (this handles both left and right, you'll need to check which is happening)
					movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);

					//Left and Right Animations
					if(Input.GetKey(KeyCode.A) && !attacking)
					{
						spriteUp.SetActive(false);
						spriteDown.SetActive(false);
						spriteRight.SetActive(false);
						spriteLeft.SetActive(true);
					}
					else if (Input.GetKey(KeyCode.D) && !attacking)
					{
						spriteUp.SetActive(false);
						spriteDown.SetActive(false);
						spriteRight.SetActive(true);
						spriteLeft.SetActive(false);
					}
				}
			}
			//added else statement here so when player is not moving, idle animation will play (walking animation will not play).
			else
			{
				animUp.SetBool("Walking", false);
				animDown.SetBool("Walking", false);
				animRight.SetBool("Walking", false);
				animLeft.SetBool("Walking", false);
			}

		}
		

	}
}
