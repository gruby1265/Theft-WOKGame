using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    bool isRiched = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (isRiched) return;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            if (PlayerPrefs.GetInt("levelReached", 1) == SceneManager.GetActiveScene().buildIndex){
                PlayerPrefs.SetInt("levelReached", PlayerPrefs.GetInt("levelReached", 1)+1);
            }
            isRiched = true;
        }
    }
}
