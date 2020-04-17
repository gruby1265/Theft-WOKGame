using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obrazSender : MonoBehaviour
{
    public obraz obr;
    public paintingDisplay ptds;
    SpriteRenderer paintRender;

    void Start()
    {
        paintRender = GetComponent<SpriteRenderer>();
        paintRender.sprite = obr.painting;
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player"){
            GameManager.onPainting = true;
        }
    }
}
