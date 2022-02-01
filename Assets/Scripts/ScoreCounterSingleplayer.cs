using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounterSingleplayer : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Text scoreDisplay;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        float score = player.position.x - transform.position.x;
        scoreDisplay.text = "" + Math.Round(score);
    }
}
