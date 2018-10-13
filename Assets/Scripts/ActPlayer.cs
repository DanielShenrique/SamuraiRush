using UnityEngine;
using UnityEngine.SceneManagement;

public class ActPlayer : MonoBehaviour {

    /// <summary>
    /// Daniel esse é o script do player. Luiz é Ziul
    /// </summary>

    private string state;

    private int limiar;

    private bool canJump;
    private bool canDestroyObject;

    private Rigidbody2D rb;

    private Vector3 mouse;

    public Animator animator;

    private Points point;

    public GameObject MenuScored;
    public GameObject HighScored;

    void Awake()
    {
        canJump = true;
    }

    void Start()
    {
        limiar = Screen.width / 10;

        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        point = GameObject.FindGameObjectWithTag("Points").GetComponent<Points>();
    }

    void Update()
    {
		BasicFunction();

		switch (state)
		{
			case "up":
				if (transform.position.y < 0.5f)
				{
					transform.position = new Vector2(transform.position.x, transform.position.y + 0.2f);
				}
				else
				{
					state = "down";
				}
				break;

			case "down":
				if (transform.position.y >= -3.7f)
				{
					transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);
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
                if(transform.position.x <= 2f)
                {
                    transform.position = new Vector2(transform.position.x + 0.7f, transform.position.y);
                    canDestroyObject = true;
                    //Alterei isso
                    animator.SetBool("jumpDash", true);
                    //A alteração acabou
                }
                else
                {
                    state = "dashBack";
                    //Alterei isso
                    animator.SetBool("isDashing", false);
                    //A alteração acabou
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
                }
                break;
		}

        print(canDestroyObject);
        //Alterei isso
        if (canJump == true)
        {
            EndAnimationJump();
        }
        //A alteração acabou
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
                    //Alterei isso
                    animator.SetBool("isJumping", true);
                    //A alteração acabou
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
            //Alterei isso
            animator.SetBool("isDashing", true);
            //A alteração acabou
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
            if(coll.transform.gameObject.GetComponent<DestroyPettern>().GetCanDestroy() && canDestroyObject == true)
            {
                point.num += 100;
                Destroy(coll.gameObject);
            }
            else
            {
                    Destroy(this.gameObject);
                    MenuScored.SetActive(true);
                    HighScored.SetActive(true);              
            }

        }
        if (coll.gameObject.tag.Equals("Coin"))
        {
            point.num += 500;
            Destroy(coll.gameObject);
        }
    }
}
