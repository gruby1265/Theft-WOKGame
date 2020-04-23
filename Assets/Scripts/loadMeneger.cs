using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

public class loadMeneger : MonoBehaviour
{
    public Button[] levelButtons;

    void Start()
    {
        Load();
    }

    public void Load(){
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i > PlayerPrefs.GetInt("levelReached", 1)-1){
                levelButtons[i].interactable = false;
            }
        }
    }

}
