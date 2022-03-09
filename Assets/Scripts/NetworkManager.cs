using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour
{
    //Method for Server Connection
    private string selectedPlayerName;
    public bool isStarted = false;
    [SerializeField] private GameObject startGameButton;
    [SerializeField] private GameObject startBarrier;
    [SerializeField] private GameObject endScreenBG;
    [SerializeField] private GameObject endScreenButton;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject gameWonText;
    [SerializeField] private GameObject controlsUI;
    [SerializeField] private GameObject FPSCounter;

    public void BackToMenu()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("MainMenu");
    }
    public void Player_1()
    {
        selectedPlayerName = "Player_1";
        PlayerPrefs.SetString("selectedPlayerName", selectedPlayerName);
        PlayerPrefs.Save();
        Connect();
    }

    public void Player_2()
    {
        selectedPlayerName = "Player_2";
        PlayerPrefs.SetString("selectedPlayerName", selectedPlayerName);
        PlayerPrefs.Save();
        Connect();
    }

    public void Player_3()
    {
        selectedPlayerName = "Player_3";
        PlayerPrefs.SetString("selectedPlayerName", selectedPlayerName);
        PlayerPrefs.Save();
        Connect();
    }

    public void Player_4()
    {
        selectedPlayerName = "Player_4";
        PlayerPrefs.SetString("selectedPlayerName", selectedPlayerName);
        PlayerPrefs.Save();
        Connect();
    }

    public void Player_5()
    {
        selectedPlayerName = "Player_5";
        PlayerPrefs.SetString("selectedPlayerName", selectedPlayerName);
        PlayerPrefs.Save();
        Connect();
    }

    public void Player_6()
    {
        selectedPlayerName = "Player_6";
        PlayerPrefs.SetString("selectedPlayerName", selectedPlayerName);
        PlayerPrefs.Save();
        Connect();
    }
    public void Player_7()
    {
        selectedPlayerName = "Player_7";
        PlayerPrefs.SetString("selectedPlayerName", selectedPlayerName);
        PlayerPrefs.Save();
        Connect();
    }

    public void Player_8()
    {
        selectedPlayerName = "Player_8";
        PlayerPrefs.SetString("selectedPlayerName", selectedPlayerName);
        PlayerPrefs.Save();
        Connect();
    }

    public void Player_9()
    {
        selectedPlayerName = "Player_9";
        PlayerPrefs.SetString("selectedPlayerName", selectedPlayerName);
        PlayerPrefs.Save();
        Connect();
    }
    public void Player_10()
    {
        selectedPlayerName = "Player_10";
        PlayerPrefs.SetString("selectedPlayerName", selectedPlayerName);
        PlayerPrefs.Save();
        Connect();
    }
    public void Player_11()
    {
        selectedPlayerName = "Player_11";
        PlayerPrefs.SetString("selectedPlayerName", selectedPlayerName);
        PlayerPrefs.Save();
        Connect();
    }


    public void Connect()
    {
        SceneManager.LoadScene("RoomList");
    }

    

    void OnJoinedRoom()
    {
        Spawn();
    }
    public void Spawn()
    {
        string selectedPlayerNameLoc = PlayerPrefs.GetString("selectedPlayerName");
        PhotonNetwork.Instantiate(selectedPlayerNameLoc, new Vector3(-9.19f, -1.67f, -2), Quaternion.identity, 0);
    }

    public void StartGame()
    {
        isStarted = true;
        PlayerPrefs.SetString("isStarted", "true");
        PlayerPrefs.Save();
        startGameButton.SetActive(false);
    }

    void Start()
    {
        isStarted = false;
        startGameButton.SetActive(false);
        endScreenBG.SetActive(false);
        endScreenButton.SetActive(false);
        gameOverText.SetActive(false);
        gameWonText.SetActive(false);
        PlayerPrefs.SetString("isStarted", "false");
        PlayerPrefs.SetString("isDead", "false");
        PlayerPrefs.SetString("hasWon", "false");
        PlayerPrefs.Save();
    }

    void Update()
    {
        if (PlayerPrefs.GetString("isStarted") == "true")
        {
            startBarrier.SetActive(false);
        }

        if (PlayerPrefs.GetString("isDead") == "true" && PlayerPrefs.GetString("hasWon") == "false")
        {
            endScreenBG.SetActive(true);
            endScreenButton.SetActive(true);
            gameOverText.SetActive(true);
            controlsUI.SetActive(false);
            FPSCounter.SetActive(false);
        }

        if (PlayerPrefs.GetString("hasWon") == "true")
        {
            endScreenBG.SetActive(true);
            endScreenButton.SetActive(true);
            gameWonText.SetActive(true);
            controlsUI.SetActive(false);
            FPSCounter.SetActive(false);
        }


        if (PlayerPrefs.GetString("isMaster") == "true" && PlayerPrefs.GetString("isStarted") == "false")
        {
            startGameButton.SetActive(true);
        }

        if(PlayerPrefs.GetString("isStarted") == "true" || PlayerPrefs.GetString("isMaster") != "true")
        {
            startGameButton.SetActive(false);
        }

        int Players = PhotonNetwork.otherPlayers.Length + 1;
        //Debug.Log(PhotonNetwork.connectionStateDetailed.ToString());
        //Debug.Log("Anzahl der Spieler: " + Players.ToString());
    }
}

