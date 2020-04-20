using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torch : MonoBehaviour
{
    Collider2D col;
    playerMove playerReference;
    bool damageTaken = false;

    void Start()
    {
        playerReference = GameObject.FindWithTag("Player").GetComponent<playerMove>();
        col = transform.GetChild(0).gameObject.GetComponent<PolygonCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (damageTaken) return;
        if(other.tag == "Player")
        {
            GameManager.HP--;
            col.enabled = false;
            damageTaken = true;
            playerReference.hurt(2f);
            Invoke("makeLightAgain", 2f);
        }
    }

    void makeLightAgain()
    {
        col.enabled = true;
        damageTaken = false;
    }
}
