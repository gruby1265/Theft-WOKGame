using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using UnityEngine.SceneManagement;
using TMPro;
using System;


public class loadLevels : MonoBehaviour
{
    TextMeshProUGUI level;
    public void LoadLevel(){
        Time.timeScale = 1f;
        level = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        SceneManager.LoadScene(Int32.Parse(level.text));
    }
}
