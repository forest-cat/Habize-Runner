using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private Text fpsDisplay;
    private float fpsSum = 0f;
    private int counter = 0;
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        float fps = 1 / Time.unscaledDeltaTime;
        
        if (counter == 100)
        {
            float frames = fpsSum / 100;
            fpsDisplay.text = "FPS: " + Math.Round(frames);
            fpsSum = 0;
            counter = 0;
        }


        fpsSum += fps;
        counter++;
    }
}
