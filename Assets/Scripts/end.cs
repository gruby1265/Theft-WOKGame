using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour
{

    void Start()
    {
        Load();
    }

    void Load(){
        StartCoroutine(Loader());
    }

    IEnumerator Loader(){
        yield return new WaitForSeconds(31f);
        SceneManager.LoadScene(0);
    }

}
