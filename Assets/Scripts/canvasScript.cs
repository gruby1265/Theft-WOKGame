using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//!!!
using TMPro;

public class canvasScript : MonoBehaviour
{
    GameObject textGo;
    TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        score = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        score.text = GameManager.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = GameManager.score.ToString();
    }
}