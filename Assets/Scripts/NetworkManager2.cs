using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NetworkManager2 : MonoBehaviour
{
    [SerializeField] private InputField CreateInputField;
    [SerializeField] private InputField JoinInputField;
    [SerializeField] private GameObject createButton;
    [SerializeField] private GameObject joinButton;
    [SerializeField] private Text errorMessageText;
    [SerializeField] private GameObject errorMessageGameObject;

    private bool coroutineIsRunning = false;


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

    void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
    }



    public void CreateRoom()
    {

        RoomInfo[] rooms = PhotonNetwork.GetRoomList();
        string roomID = Random.Range(5, 999999).ToString();


        if (rooms.Length <= 0)
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
                PhotonNetwork.CreateRoom(roomID);
                PlayerPrefs.SetString("RoomID", roomID);
                PlayerPrefs.Save();
                SceneManager.LoadScene("Multiplayer");
            }
        }


        for (int i = 0; i < rooms.Length; i++)
        {

            if (rooms[i].Name != CreateInputField.text && rooms[i].Name != roomID)
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

                    PhotonNetwork.CreateRoom(roomID);
                    PlayerPrefs.SetString("RoomID", roomID);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("Multiplayer");
                }
            }
            else
            {

                Debug.Log("This Room is already existing");
                StartCoroutine(ShowError("This Room is already existing"));

            } 
        }
        
        IEnumerator ShowError(string text)
        {
            Debug.Log("running");
            coroutineIsRunning = true;
            errorMessageGameObject.SetActive(true);
            errorMessageText.text = text;
            yield return new WaitForSeconds(5);
            errorMessageGameObject.SetActive(false);
            coroutineIsRunning = false;
            Debug.Log("stopped");
        }


        Debug.Log("Room created with: " + PlayerPrefs.GetString("RoomID"));
    }

    public void JoinRoom()
    {
        if (JoinInputField.text != "")
        {
            RoomInfo[] rooms = PhotonNetwork.GetRoomList();

            
            if (rooms.Length <= 0)
            {
                Debug.Log("In this Lobby arent any Rooms, create one using create Button");
                StartCoroutine(ShowError("In this Lobby arent any Rooms, create one using create Button"));
            }
            else
            {
                for (int i = 0; i < rooms.Length; i++)
                {
                    Debug.Log(rooms[i].Name);
                    if (rooms[i].Name == JoinInputField.text)
                    {
                        if (rooms[i].IsOpen)
                        {
                            PhotonNetwork.JoinRoom(JoinInputField.text);
                            PlayerPrefs.SetString("RoomID", JoinInputField.text);
                            PlayerPrefs.Save();
                            SceneManager.LoadScene("Multiplayer");
                            break;
                        }
                        else
                        {
                            Debug.Log("The Game already started");
                            StartCoroutine(ShowError("The Game already started"));
                        }
                        
                    }
                    else
                    {
                        Debug.Log("This Room isnt existing, check your Room Code or create one using create Button");
                        StartCoroutine(ShowError("This Room isnt existing, check your Room Code or create one using create Button"));
                    }
                }
            }
        }
        else
        {
            Debug.Log("Enter a Room ID first!");
            StartCoroutine(ShowError("Enter a Room ID first!"));
        }


        IEnumerator ShowError(string text)
        {
            Debug.Log("running");
            coroutineIsRunning = true;
            errorMessageGameObject.SetActive(true);
            errorMessageText.text = text;
            yield return new WaitForSeconds(5);
            errorMessageGameObject.SetActive(false);
            coroutineIsRunning = false;
            Debug.Log("stopped");
        }
    }


    void Update()
    {

    }
}
