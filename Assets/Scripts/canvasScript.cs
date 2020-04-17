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
    void Start()
    {
        paintingMenu = transform.GetChild(1).gameObject;
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
        if (GameManager.onPainting){
            
            //Time.timeScale = 0f;
            paintingMenu.SetActive(true);
        }else{
            //Time.timeScale = 1f;
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

    public void save()
    {
        Debug.Log("Save");
    }

    public void options()
    {
        Debug.Log("Options");
    }

    public void exit()
    {
        Debug.Log("Exit");
        SceneManager.LoadScene(0);
    }
}