using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformGoDown : MonoBehaviour
{
    PlatformEffector2D PlatEff;
    float changeTime;
    public float changeInterwals = 4f;

    // Start is called before the first frame update
    void Start()
    {
        PlatEff = GetComponent<PlatformEffector2D>();
        changeTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (changeTime > 0)
        {
            changeTime -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlatEff.rotationalOffset = 180f;
            changeTime = changeInterwals;
        }
        else if (changeTime < 0)
        {
            PlatEff.rotationalOffset = 0f;
            changeTime = 0;
        }
    }
}
