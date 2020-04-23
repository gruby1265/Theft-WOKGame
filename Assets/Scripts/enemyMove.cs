using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public Transform[] point;
    Transform target;
    Rigidbody2D rb;

    public bool goLeft;
    [SerializeField]
    float speed = 4f;

    int i = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = point[0];
        if (!goLeft)
        {
            flip();
        }
    }

    void FixedUpdate()
    {
        if(Mathf.Abs(transform.position.x - target.position.x) < 0.1f)
        {
            flip();
            i++;
            if (i == point.Length)
            {
                i = 0;
            }
            target = point[i];
            goLeft = !goLeft;
        }

        if (goLeft)
        {
            rb.velocity = new Vector2(-speed * Time.fixedDeltaTime, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
        }
    }

    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
