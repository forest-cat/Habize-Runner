using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

    private Transform player;
    [SerializeField] private Text scoreDisplay;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string selectedPlayerName = PlayerPrefs.GetString("selectedPlayerName");
        player = GameObject.Find(selectedPlayerName + "(Clone)").transform;
        float score = player.position.x - transform.position.x;
        scoreDisplay.text = "" + Math.Round(score);
    }
}
