using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class paintingDisplay : MonoBehaviour
{
    obraz obr;
    public obrazSender obrSender;
    TextMeshProUGUI author;
    TextMeshProUGUI description;
    Image obraz;

    bool takenData;

    void Start()
    {
        takenData = false;
        author = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        description = transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        obraz = transform.GetChild(3).gameObject.GetComponent<Image>();
    }

    void Update()
    {
        if (GameManager.onPainting && !takenData)
        {
            obr = obrSender.obr;
            author.text = obr.author;
            description.text = obr.descripction;
            obraz.sprite = obr.painting;
            takenData = true;

        }
    }

    public void closePaintingDispay(){
        Time.timeScale = 1f;
        takenData = false;
        GameManager.onPainting = false;
        gameObject.SetActive(false);
    }
}
