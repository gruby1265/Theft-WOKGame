using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public AudioMixer audio;
    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void ResetPrefs(){
        PlayerPrefs.DeleteAll();
    }

    public void SetVolume(float volume){
        audio.SetFloat("volume", volume);
    }
}
