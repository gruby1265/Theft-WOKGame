using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int score;
    public static int HP;
    public static int maxHP = 6;
    public static bool onPainting;
    public static obraz paintingDisp;

    // Start is called before the first frame update
    void Awake()
    {
        score = 0;
        HP = maxHP;
        onPainting = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
