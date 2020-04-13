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

    GameObject pauseMenu;
    bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        score = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
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