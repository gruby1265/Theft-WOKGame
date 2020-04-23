using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectibleScript : MonoBehaviour
{
    bool isCollected = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isCollected) return;
        if (other.tag == "Player")
        {
            isCollected = true;
            switch (tag)
            {
                case "Coin":
                    GameManager.score++;
                    Destroy(gameObject);
                    break;
                case "DamageDealer":
                    GameManager.HP--;
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
