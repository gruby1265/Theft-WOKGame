using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//!!!
using TMPro;
using UnityEngine.SceneManagement;

public class canvasScript : MonoBehaviour
{
    GameObject textGo;
    TextMeshProUGUI score;
    GameObject paintingMenu;

    GameObject pauseMenu;
    bool isPaused;

    // Start is called before the first frame update

    void Awake(){
        paintingMenu = transform.GetChild(1).gameObject;
        paintingMenu.SetActive(true);
    }

    void Start()
    {
        score = transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        pauseMenu = transform.GetChild(0).gameObject;

        isPaused = false;
        score.text = GameManager.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                unpause();
            }
            else
            {
                pause();
            }
        }


        score.text = GameManager.score.ToString();
        PlayerPrefs.SetInt("score", GameManager.score);
        if (GameManager.onPainting){
            Time.timeScale = 0f;
            paintingMenu.SetActive(true);
        }else{
            paintingMenu.SetActive(false);
        }
    }

    void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void unpause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    
    public void exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}