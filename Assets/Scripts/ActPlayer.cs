using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActPlayer : MonoBehaviour {

	/// <summary>
	/// Daniel esse é o script do player. Luiz é Ziul
	/// </summary>

	private string state;
	
    private int limiar;

    private Vector3 mouse;

    public Animator animator;

    private Rigidbody2D rb;

    private bool canJump;

    void Awake()
    {
        canJump = true;
    }

    void Start()
    {
        limiar = Screen.width / 10;

        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }

    void Update()
    {
		BasicFunction();

		/*switch (state)
		{
			case "up":
				if (transform.position.y < 0.5f)
				{
					transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
				}
				else
				{
					state = "down";
				}
				break;

			case "down":
				if (transform.position.y >= -3.7f)
				{
					transform.position = new Vector2(transform.position.x, transform.position.y - 0.35f);
				}
				else
				{
					state = "stopped";
				}
				break;

            case "dashGo":
                if(transform.position.x < 2.7f)
                {
                    transform.position = new Vector2(transform.position.x + 0.7f, transform.position.y);
                }
                else
                {
                    state = "dashBack";
                }
                break;
            case "dashBack":
                if(transform.position.x > 2.7f)
                {
                    transform.position = new Vector2(transform.position.x - 0.7f, transform.position.y);
                }
                else
                {
                    state = "stopped";
                }
                break;
		}*/
    }

    void BasicFunction()
    {
       if (Input.GetMouseButtonDown(0))
       {
			mouse = Input.mousePosition;

			Invoke("RealJump", 0.05f);
			Invoke("Swipe", 0.05f);

       }
    }

    #region fuctionsBases
    void RealJump()
    {
        if (canJump)
        {
            if (Input.GetMouseButton(0))
            {
                if (Input.mousePosition.x - mouse.x < limiar)
                {
                    canJump = false;
					state = "up";		
                }
            }
        }
    }

    void Swipe()
    {
        if(Input.mousePosition.x - mouse.x >= limiar)
        {
			state = "dashGo";
        }
    }

    #endregion

    #region EndAnims

    void EndAnimationDash()
    {
        animator.SetBool("isDashing", false);
    }

    void EndAnimationJump()
    {
        animator.SetBool("isJumping", false);
    }
    #endregion

    void OnCollisionEnter2D(Collision2D coll)
    {   
        if (coll.gameObject.tag.Equals("Ground"))
        {
            canJump = true;
        }

        if (coll.gameObject.tag.Equals("Barrel"))
        {
			Destroy(this.gameObject);
        }
    }
}
