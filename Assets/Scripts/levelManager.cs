using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    public Animator anim;
    bool isReached = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (isReached) return;
            LoadNextLevel();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
            isReached = true;
        }
    }

    public void LoadNextLevel(){
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex){
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        if (PlayerPrefs.GetInt("levelReached", 1) == SceneManager.GetActiveScene().buildIndex){
                PlayerPrefs.SetInt("levelReached", PlayerPrefs.GetInt("levelReached", 1)+1);
            }
        SceneManager.LoadScene(levelIndex);
    }
}
