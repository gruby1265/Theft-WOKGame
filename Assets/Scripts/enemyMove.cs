using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    [SerializeField]
    Transform[] point;
    Transform target;
    Rigidbody2D rb;

    public bool goLeft;
    [SerializeField]
    float speed = 4f;

    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = point[0];
        if (!goLeft)
        {
            flip();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Mathf.Abs(transform.position.x - target.position.x) < 0.1f)
        {
            flip();
            i++;
            if (i == 2)
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
