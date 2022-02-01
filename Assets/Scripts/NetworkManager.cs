using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour
{
    //Method for Server Connection

    

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
        Debug.Log("Joined Lobby");
        // Random Raum betreten
        PhotonNetwork.JoinRandomRoom();
        
        
    }
    
    void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom()
    {
        Spawn();
    }
    public void Spawn()
    {
        PhotonNetwork.Instantiate("Player_1",new Vector3(-9.19f, -1.67f, 0), Quaternion.identity, 0);
    }
    

    void Update()
    { 
        int Players = PhotonNetwork.otherPlayers.Length + 1;
        //Debug.Log(PhotonNetwork.connectionStateDetailed.ToString());
        Debug.Log("Anzahl der Spieler: " + Players.ToString());
    }
}
