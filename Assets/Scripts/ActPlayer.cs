using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActPlayer : MonoBehaviour {

    /// <summary>
    /// Daniel esse é o script do player.
    /// </summary>

    private int limiar;

    private Vector3 mouse;

    private Animator animator;

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

        //animator.speed = 1.5f;
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
                    animator.SetBool("isJumping", true);
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

    #region EndAnims
    void EndAnimation()
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
			print("aee");
        }

        if (coll.gameObject.tag.Equals("Points"))
        {
            Debug.Log("AEEEEE");
        }
    }
}
