using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obrazSender : MonoBehaviour
{
    public obraz obr;
    paintingDisplay ptds;
    SpriteRenderer paintRender;

    void Start()
    {
        paintRender = GetComponent<SpriteRenderer>();
        paintRender.sprite = obr.painting;
        ptds = GameObject.FindWithTag("PaintingMenu").GetComponent<paintingDisplay>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player"){
            GameManager.onPainting = true;
            ptds.obrSender = this;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
