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
        obraz.enabled = false;
        author.enabled = false;
        description.enabled = false;
    }

    void Update()
    {
        if (GameManager.onPainting && !takenData)
        {
            obraz.enabled = true;
            author.enabled = true;
            description.enabled = true;
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
        author.text = null;
        description.text = null;
        obraz.sprite = null;
        obraz.enabled = false;
        author.enabled = false;
        description.enabled = false;
        GameManager.onPainting = false;
        gameObject.SetActive(false);
        GameManager.score += 20;
    }
}
