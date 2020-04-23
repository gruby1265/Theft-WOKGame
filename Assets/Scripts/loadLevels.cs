using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using UnityEngine.SceneManagement;
using TMPro;
using System;


public class loadLevels : MonoBehaviour
{
    public Animator anim;
    TextMeshProUGUI level;
    public void LoadLevel(){
        Time.timeScale = 1f;
        level = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        StartCoroutine(Load(Int32.Parse(level.text)));
    }

    IEnumerator Load(int sceneIndex){
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneIndex);
    }
}
