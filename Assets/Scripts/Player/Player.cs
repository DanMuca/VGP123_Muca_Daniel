using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
public class Player : MonoBehaviour
{
    public bool verbose = false;
    public bool isGrounded;


    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    [SerializeField]
    float speed;

    [SerializeField]
    int jumpForce;

    [SerializeField]
    float groundCheckRadius;

    [SerializeField]
    LayerMask isGroundLayer;

    [SerializeField]
    Transform groundCheck;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        if (speed <= 0)
        {
            speed = 5.0f;
            if (verbose)
                Debug.Log("Speed Changed to default value of 5");
        }

        if (jumpForce <= 0)
        {
            jumpForce = 300;
            if (verbose)
                Debug.Log("Jump Force changed to the default value of 300");
        }

        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.05f;
            if (verbose)
                Debug.Log("Ground Check Radius changed to default value of 0.05");
        }

        if (!groundCheck)
        {
            groundCheck = transform.GetChild(0);
            if (verbose)
            {
                if (groundCheck.name == "GroundCheck")
                
                    Debug.Log("Ground Check Found and Assigned");
                    else
                    Debug.Log("Manually set ground as it could not be found");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
        }

        Vector2 moveDir = new Vector2(hInput * speed, rb.velocity.y);
        rb.velocity = moveDir;

        anim.SetFloat("xVel", Mathf.Abs(hInput));
        anim.SetBool("IsGrounded", isGrounded);
        
        
        
        //My Implemented Code
        
        anim.SetBool("LCtrl", false);
        anim.SetBool("UpArrow", false);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            anim.SetBool("LCtrl", true);
        }
        
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("UpArrow", true);
        }

        if (hInput < 0 )
        {
            sr.flipX = true;
        }
        if (hInput > 0)
        {
            sr.flipX = false;
        }

    }
}
