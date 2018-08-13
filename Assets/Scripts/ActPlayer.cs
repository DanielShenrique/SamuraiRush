using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActPlayer : MonoBehaviour {

	/// <summary>
	/// This is a mobile Game; Daniel não invente de fazer nada que fuja disso, ok ? ok, estamos combinados.
	/// </summary>

	private bool canJump;

	private float speed;

	private Vector2 jumpSpeed;

	private Rigidbody2D rb;

	
	public float Speed
	{
		get
		{
			return speed;
		}
		set
		{
			speed = value;
		}
	}

	public Vector2 JumpSpeed
	{
		get
		{
			return jumpSpeed;
		}
		set
		{
			jumpSpeed = value;
		}
	}


	void Start()
	{
		canJump = true;

		speed = 5f;

		jumpSpeed = Vector2.up * 10f;

		rb = GetComponent<Rigidbody2D>();
	}

	void Update()//usando normalmente
	{
		
	}

	void FixedUpdate()//usando RB
	{
		Basicfunction();
	}

	void Basicfunction()
	{
		if(canJump == true)
		{
			if (Input.GetMouseButtonDown(0))
			{
				rb.AddForce(jumpSpeed, ForceMode2D.Impulse);
				canJump = false;
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag.Equals("Ground"))
		{
			canJump = true;
		}
	}
}
