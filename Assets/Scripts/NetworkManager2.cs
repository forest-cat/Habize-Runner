using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NetworkManager2 : MonoBehaviour
{
    [SerializeField] private InputField CreateInputField;
    [SerializeField] private InputField JoinInputField;
    [SerializeField] private GameObject createButton;
    [SerializeField] private GameObject joinButton;


    void Start()
    {
        createButton.GetComponent<Button>().interactable = false;
        joinButton.GetComponent<Button>().interactable = false;
        PhotonNetwork.ConnectUsingSettings("v1.6");
    }

    void OnConnectedToMaster()
    {
        Debug.Log("Connected to Masterserver");
        PhotonNetwork.JoinLobby();
        createButton.GetComponent<Button>().interactable = true;
        joinButton.GetComponent<Button>().interactable = true;
    }



    public void CreateRoom()
    {
        
        if (CreateInputField.text != "")
        {
            PhotonNetwork.CreateRoom(CreateInputField.text);
            PlayerPrefs.SetString("RoomID", CreateInputField.text);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Multiplayer");
        }
        else
        {
            string roomID = Random.Range(5, 999999).ToString();
            PhotonNetwork.CreateRoom(roomID);
            PlayerPrefs.SetString("RoomID", roomID);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Multiplayer");
        }
        Debug.Log("Room created with: " + PlayerPrefs.GetString("RoomID"));
    }

    public void JoinRoom()
    {
        if (JoinInputField.text != "")
        {
            PhotonNetwork.JoinRoom(JoinInputField.text);
            PlayerPrefs.SetString("RoomID", JoinInputField.text);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Multiplayer");
        }
    }


    void Update()
    {
        
    }
}
