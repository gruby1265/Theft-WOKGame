using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HPDisplay : MonoBehaviour
{
    int HPDisplayed;
    SpriteRenderer sprRend;

    // Start is called before the first frame update
    void Start()
    {
        sprRend = GetComponent<SpriteRenderer>();
        sprRend.size = new Vector2(GameManager.HP, 1f);
        HPDisplayed = GameManager.HP;
        transform.position = new Vector2(transform.position.x + transform.localScale.x * (float)GameManager.HP / 126f, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(HPDisplayed != GameManager.HP)
        {
            if (GameManager.HP <= 0){
                GameManager.score -= 10;
                PlayerPrefs.SetInt("score", GameManager.score);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            sprRend.size = new Vector2(GameManager.HP, 1f);
            if(HPDisplayed > GameManager.HP)
            {
                transform.position = new Vector2(transform.position.x - transform.localScale.x / 126f, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(transform.position.x + transform.localScale.x / 126f, transform.position.y);
            }
            HPDisplayed = GameManager.HP;
        }
    }
}
