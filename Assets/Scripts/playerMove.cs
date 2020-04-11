using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float move;
    public float speed = 5f;
    public float jumpStr = 6f;
    public float moveSmooth = 0.05f;

    public LayerMask whatIsGround;
    public Transform groundCheck;
    float checkGroundRadius = 0.1f;

    public Transform roofCheck;
    public Collider2D head;
    float checkRoofRadius = 0.2f;

    bool isFRight;
    bool isGrounded;
    bool isRoofed;
    bool makeJump;

    Vector3 velZero = Vector3.zero;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isFRight = true;
    }

    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        makeJump = Input.GetKey(KeyCode.W);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkGroundRadius, whatIsGround);
        isRoofed = Physics2D.OverlapCircle(roofCheck.position, checkRoofRadius, whatIsGround);

        if (makeJump && isGrounded && head.enabled)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStr);
        }

        if (Input.GetKey(KeyCode.C) && isGrounded)
        {
            if (head.enabled)
            {
                speed *= 0.1f;
            }
            head.enabled = false;
        }else if (!isRoofed && !head.enabled)
        {
            head.enabled = true;
            speed *= 10f;
        }


        if(move > 0 && !isFRight)
        {
            flip();
        } else if (move < 0 && isFRight)
        {
            flip();
        }

        if (isGrounded)
        {
            anim.SetBool("isJumpAnim", false);
            if (move != 0)
            {
                anim.SetBool("isRunAnim", true);
            }
            else
            {
                anim.SetBool("isRunAnim", false);
            }
        }else
        {
            anim.SetBool("isRunAnim", false);
            anim.SetBool("isJumpAnim", true);
        }

        rb.velocity = Vector3.SmoothDamp(rb.velocity, new Vector2(move * speed, rb.velocity.y), ref velZero, moveSmooth);
    }

    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        isFRight = !isFRight;
    }
}
