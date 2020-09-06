using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using UnityEngine;

public class Player : Character
{

	// Start is called before the first frame update
	void Start()
	{
		movePoint.parent = null;
	}

	// Update is called once per frame
	protected override void Update()
	{
		base.Update();
		GetInput();
	}

	private void GetInput()
	{
		if(Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
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
