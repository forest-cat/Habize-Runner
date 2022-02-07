using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour
{
    //Method for Server Connection
    private string selectedPlayerName;


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


    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings("v1.3");
        SceneManager.LoadScene("Multiplayer");
    }

    void OnConnectedToMaster()
    {
        Debug.Log("Connected to Masterserver");
        PhotonNetwork.JoinLobby();
    }

    void OnJoinedLobby()
    {
        // Random Raum betreten
        Debug.Log("Joined Lobby");
        PhotonNetwork.JoinRandomRoom();
        
        
    }
    
    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Failed to Join Room");
        PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom()
    {
        Spawn();
    }
    public void Spawn()
    {
        string selectedPlayerNameLoc = PlayerPrefs.GetString("selectedPlayerName");
        PhotonNetwork.Instantiate(selectedPlayerNameLoc, new Vector3(-9.19f, -1.67f, 0), Quaternion.identity, 0);
    }
    

    void Update()
    { 
        int Players = PhotonNetwork.otherPlayers.Length + 1;
        //Debug.Log(PhotonNetwork.connectionStateDetailed.ToString());
        Debug.Log("Anzahl der Spieler: " + Players.ToString());
    }
}
