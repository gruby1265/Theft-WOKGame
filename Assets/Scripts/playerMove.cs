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
    float jump;

    Vector3 velZero = Vector3.zero;

    Animator anim;

    bool onLadder;
    bool inFrontLadder;

    bool hasKey;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isFRight = true;
        onLadder = false;
        hasKey = false;
    }

    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("speedAnim", Mathf.Abs(move));
        jump = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (!onLadder)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkGroundRadius, whatIsGround);
            isRoofed = Physics2D.OverlapCircle(roofCheck.position, checkRoofRadius, whatIsGround);

            if (jump > 0 && isGrounded && head.enabled && !inFrontLadder)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpStr);
            }

            if (Input.GetKey(KeyCode.C) && isGrounded)
            {
                if (head.enabled)
                {
                    speed *= 0.1f;
                }
                anim.SetBool("isCrouchAnim", true);
                head.enabled = false;
            }
            else if (!isRoofed && !head.enabled)
            {
                anim.SetBool("isCrouchAnim", false);
                head.enabled = true;
                speed *= 10f;
            }


            if (move > 0 && !isFRight)
            {
                flip();
            }
            else if (move < 0 && isFRight)
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
            }
            else
            {
                anim.SetBool("isRunAnim", false);
                anim.SetBool("isJumpAnim", true);
            }

            rb.velocity = Vector3.SmoothDamp(rb.velocity, new Vector2(move * speed, rb.velocity.y), ref velZero, moveSmooth);
        }
        else
        {
            onLadderAct();
        }
    }

    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        isFRight = !isFRight;
    }

    void onLadderAct()
    {
        rb.velocity = Vector3.SmoothDamp(rb.velocity, new Vector2(move * speed, jump * jumpStr), ref velZero, moveSmooth);
    }

    bool trigStayDone = false;
    void OnTriggerStay2D(Collider2D other)
    {
        if (trigStayDone) return;
        if (other.tag == "Ladder")
        {
            inFrontLadder = true;
            if (jump > 0)
            {
                rb.gravityScale = 0;
                speed *= 0.2f;
                jumpStr *= 0.2f;
                onLadder = true;
                trigStayDone = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ladder")
        {
            inFrontLadder = false;
            if (onLadder)
            {
                rb.gravityScale = 1f;
                speed *= 5f;
                jumpStr *= 5f;
                onLadder = false;
                trigStayDone = false;
            }
        }
    }

    public void takeKey()
    {
        Debug.Log("mam klucz");
        hasKey = true;
    }
}
