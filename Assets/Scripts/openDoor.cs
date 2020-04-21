using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public Sprite openedDoorSpr;
    SpriteRenderer sprRend;
    bool hasChanged;
    Collider2D coll;

    void Start()
    {
        hasChanged = false;
        sprRend = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasChanged) return;
        if(other.tag == "Player")
        {
            if (other.GetComponent<playerMove>().doIHaveKey())
            {
                sprRend.sprite = openedDoorSpr;
                coll.enabled = false;
                hasChanged = true;
            }
        }
    }
}
