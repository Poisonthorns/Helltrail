using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField]
	private Stat health;
	[SerializeField]
	private float startingHealth;
	[SerializeField]
	private float maxHealth;
	[SerializeField]
	private float speed;
	[SerializeField]
	protected Transform movePoint;
	public LayerMask collideables;
	// Start is called before the first frame update
	void Start()
	{
		movePoint.parent = null;
		health.Initialize(startingHealth, maxHealth);
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
		GetInput();
	}

	private void GetInput()
	{

		//Testing purposes only
		if(Input.GetKeyDown(KeyCode.O))
		{
			health.myCurrentValue -= 10;
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			health.myCurrentValue += 10;
		}

		if (Vector3.Distance(transform.position, movePoint.position) <= 0.02f)
		{
			if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
			{
				if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, collideables))
				{
					movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
				}
			}
			else if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
			{
				if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, collideables))
				{
					movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
				}
			}
			
		}

	}


}
