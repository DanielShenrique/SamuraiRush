using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActPlayer : MonoBehaviour {

	/// <summary>
	/// This is a mobile Game; Daniel não invente de fazer nada que fuja disso, ok ? ok, estamos combinados.
	/// </summary>

	private bool canJump;
    private bool tap;
    private bool swipeLeft;
    private bool swipeRight;
    private bool isDraging;

	private float speed;

	private Vector2 jumpSpeed;
    private Vector2 startTouch;
    private Vector2 swipeDelta;

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
    public Vector2 SwipeDeta
    {
        get
        {
            return swipeDelta;
        }
    }

    public bool SwipeLeft
    {
        get
        {
            return swipeLeft;
        }
    }
    public bool SwipeRight
    {
        get
        {
            return swipeRight;
        }
    }
    public bool Tap
    {
        get
        {
            return tap;
        }
    }



	void Start()
	{
		canJump = true;
        isDraging = false;

		speed = 50f;

		jumpSpeed = Vector2.up * 10f;

		rb = GetComponent<Rigidbody2D>();
	}

	void Update()//usando normalmente
	{
        tap = swipeLeft = swipeRight = false;
	}

	void FixedUpdate()//usando RB
	{
		Basicfunction();
	}

    void Reset()//usando para resetar as funções ... dahhh
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }

	void Basicfunction()
	{
        if (Input.GetMouseButtonDown(0))
            {
                tap = true;
                isDraging = true;
                startTouch = Input.mousePosition;
            }
        else if(Input.GetMouseButtonUp(0))
            {
                isDraging = false;
                Reset();
            }

        ///

        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDraging = true;
                tap = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }

        ///

        swipeDelta = Vector2.zero;
        if(isDraging)
        {
            if(Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        ///

        if(swipeDelta.magnitude > 125)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                if(x < 0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRight = true;
                }
            }

            Reset();
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
