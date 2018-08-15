using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActPlayer : MonoBehaviour {

    /// <summary>
    /// Daniel esse é o script do player.
    /// </summary>

    private float speed;

    private int limiar;

    private Vector2 jumpSpeed;
    private Vector2 dash;

    private Vector3 mouse;

    private Animator animator;

    private Rigidbody2D rb;

    private bool canJump;

    public float Speed { get { return speed; } set { speed = value; } }

    public Vector2 JumpSpeed { get { return jumpSpeed; } set { jumpSpeed = value; } }


    void Awake()
    {
        speed = 10f;

        jumpSpeed = Vector2.up * speed;
        dash = Vector2.right * speed;

        canJump = true;
    }

    void Start()
    {
        limiar = Screen.width / 6;

        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        BasicFunction();
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

    void RealJump()
    {
        if (canJump)
        {
            if (Input.GetMouseButton(0))
            {
                
                if (Input.mousePosition.x - mouse.x < limiar)
                {
                    rb.AddForce(jumpSpeed, ForceMode2D.Impulse);
                    print("u");
                    canJump = false;
                }
            }
        }
    }

    void Swipe()
    {
        if(Input.mousePosition.x - mouse.x >= limiar)
        {
            animator.SetBool("isDashing", true);
        }
    }

    void EndAnimation()
    {
        animator.SetBool("isDashing", false);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
      
        if (coll.gameObject.tag.Equals("Ground"))
        {
            canJump = true;
        }

        if (coll.gameObject.tag.Equals("Points"))
        {
            Debug.Log("AEEEEE");
        }
    }
}
