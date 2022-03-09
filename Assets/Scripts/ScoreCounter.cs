using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

    private Transform player;
    public NetworkManager networkManager;
    [SerializeField] private Text scoreDisplay;
    [SerializeField] private Text playerCount;

    


    void Update()
    {
        
        if (networkManager.isStarted || PlayerPrefs.GetString("isStarted") == "true")
        {   
            string selectedPlayerName = PlayerPrefs.GetString("selectedPlayerName");
            player = GameObject.Find(selectedPlayerName + "(Clone)").transform;
            float score = player.position.x - transform.position.x;
            scoreDisplay.text = "" + Math.Round(score);

            if (Math.Round(score) < 0)
            {
                scoreDisplay.text = "0";

            }

            if (Math.Round(score) > 1000)
            {
                PlayerPrefs.SetString("hasWon", "true");
                PlayerPrefs.SetString("isDead", "true");
                PlayerPrefs.Save();

            }

            if (PhotonNetwork.otherPlayers.Length < 1)
            {
                Debug.Log("All Players left");
                PlayerPrefs.SetString("hasWon", "true");
                PlayerPrefs.Save();
            }

            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

            if (players.Length == 1)
            {
                Debug.Log("All Players Died");
                PlayerPrefs.SetString("hasWon", "true");
                PlayerPrefs.Save();
            }


            if (playerCount.text != "")
            {
                playerCount.text = "";
            }
        }
        else
        {
            if (scoreDisplay.text != PlayerPrefs.GetString("RoomID"))
            {
                scoreDisplay.text = PlayerPrefs.GetString("RoomID");
            }
            int players = PhotonNetwork.otherPlayers.Length + 1;
            playerCount.text =  players.ToString();
        }
    }
}
