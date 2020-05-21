﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float startTime = 0f;

    
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        
    }
        



    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        string hours = ((int)t / 3600).ToString("00");
        string minutes = ((int)t / 60).ToString("00");
        string seconds = ((t % 60)).ToString("00");

        timerText.text = hours + ":" + minutes + ":" + seconds;
    }
}
