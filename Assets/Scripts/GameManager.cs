using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private InputField playerNameInputField;
    private string playerName;

    public void LoadCharacterMenu()
    {
        SceneManager.LoadScene("CharacterSelection");
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("PlayerName") || PlayerPrefs.GetString("PlayerName") == "")
        {
            playerNameInputField.text = "Player";
            PhotonNetwork.player.NickName = "Player";
            Debug.Log("PlayerName in Field set to: Player");
        }
        else
        {
            playerName = PlayerPrefs.GetString("PlayerName");
            if (playerName.Length > 20)
            {
                playerName = playerName.Substring(0, 20);
                playerNameInputField.text = playerName;
                PhotonNetwork.player.NickName = playerName;
                Debug.Log("PlayerName in Field set to: " + playerName);
            }
            else
            {
                playerNameInputField.text = playerName;
                PhotonNetwork.player.NickName = playerName;
                Debug.Log("PlayerName in Field set to: " + playerName);
            }
            
        }
        
    }

    void Update()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            if (SceneManager.GetActiveScene().name == "MainMenu" && playerNameInputField.text != "Player" && playerNameInputField.text != PlayerPrefs.GetString("PlayerName") && playerNameInputField.text != "")
            {
                PlayerPrefs.SetString("PlayerName", playerNameInputField.text);
                PlayerPrefs.Save();
                PhotonNetwork.player.NickName = playerNameInputField.text;

            }
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "MainMenu" && playerNameInputField.text != "Player" && playerNameInputField.text != "")
            {
                PlayerPrefs.SetString("PlayerName", playerNameInputField.text);
                PlayerPrefs.Save();
                PhotonNetwork.player.NickName = playerNameInputField.text;
            }
        }

        if (playerNameInputField.text.Length > 20)
        {
            playerNameInputField.text = playerNameInputField.text.Substring(0, 20);
        }
    }
}
