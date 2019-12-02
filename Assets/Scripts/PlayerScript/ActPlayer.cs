using UnityEngine;
using UnityEngine.SceneManagement;

public class ActPlayer : MonoBehaviour {

	private string state;

    private int divS;

    private bool canJump;
    private bool canDestroyObject;
    private bool canDash;

    private Vector3 mouse;

    private Animator animator;

    private Points point;

    public GameObject MenuScored;
    public GameObject HighScored;
    public GameObject Restart;
    public GameObject ClearHighscore;

    void Awake()
    {
        canJump = true;
        animator = GetComponent<Animator>();

    }

    void Start()
    {
        divS = Screen.width / 100;

        point = GameObject.FindGameObjectWithTag("Points").GetComponent<Points>();

        canDash = true;
    }

    void Update()
    {
		BasicFunction();

		switch (state)
		{
			case "up":
				if (transform.position.y < 0.5f)
				{
					transform.position = new Vector2(transform.position.x, transform.position.y + 0.32f);
				}
				else
				{
					state = "down";
				}
			break;
			case "down":
				if (transform.position.y >= -3.7f)
				{
					transform.position = new Vector2(transform.position.x, transform.position.y - 0.34f);
				}
				else
				{
                    if (transform.position.x > -7f)
                    {
                        state = "dashBack";
                    }
                    else
                    {
                        state = "stopped";
                    }

				}
			break;

            case "dashGo":
                if(transform.position.x <= 1.5f)
                {
                    transform.position = new Vector2(transform.position.x + 0.7f, transform.position.y);
                    canDestroyObject = true;
                    animator.SetBool("jumpDash", true);
                }
                else
                {
                    state = "dashBack";
                    animator.SetBool("isDashing", false);
                }
            break;
            case "dashBack":
                if(transform.position.x >= -7f)
                {
                    transform.position = new Vector2(transform.position.x - 0.7f, transform.position.y);
                }
                else
                {
                    if(transform.position.y > -3.7)
                    {
                        state = "down";
                    }
                    else
                    {
                        state = "stopped";
                    }
                    canDestroyObject = false;
                    canDash = true;
                }
            break;
		}

        if (canJump == true)
        {
            EndAnimationJump();
        }

    }

    void BasicFunction()
    {
       if (Input.GetMouseButtonDown(0))
       {
			mouse = Input.mousePosition;

			Invoke("RealJump", 0.03f);
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
                if (Input.mousePosition.x - mouse.x < divS)
                {                
                    animator.SetBool("isJumping", true);
					state = "up";	
                    canJump = false;
                    
                }
            }
        }
    }

    void Swipe()
    {
        if (canDash)
        {
            if (Input.mousePosition.x - mouse.x >= divS)
            {
                animator.SetBool("isDashing", true);
                state = "dashGo";
                canDash = false;
            }
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
            if(coll.transform.gameObject.GetComponent<DestroyPettern>().GetCanDestroy() && canDestroyObject == true)
            {
                point.num += 100;
                Destroy(coll.gameObject);
            }
            else
            {
                GameObject.FindGameObjectWithTag("Points").GetComponent<Points>().SavePoints();
                Destroy(this.gameObject);
                MenuScored.SetActive(true);
                HighScored.SetActive(true);
                Restart.SetActive(true);
                ClearHighscore.SetActive(true);
            }

        }
        if (coll.gameObject.tag.Equals("Coin"))
        {
            point.num += 500;
            Destroy(coll.gameObject);
        }
    }
}
