using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintingDisplay : MonoBehaviour
{
    obraz obr;
    public obrazSender obrSender;

    bool takenData;

    void Start()
    {
        takenData = false;
    }

    void Update()
    {
        if (GameManager.onPainting && !takenData)
        {
            obr = obrSender.obr;
            Debug.Log(obr.author);
            takenData = true;
        }
    }
}
