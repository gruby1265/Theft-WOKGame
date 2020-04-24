using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardKey : MonoBehaviour
{
    public GameObject guard;
    Animator anim;

    void Start(){
        anim = guard.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<playerMove>().takeKey();
            anim.SetTrigger("Klucz");
            Destroy(this);
        }
    }
}
