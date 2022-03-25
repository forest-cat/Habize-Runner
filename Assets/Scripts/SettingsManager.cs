using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private GameObject MultiPlayerButton;
    [SerializeField] private GameObject PlayerNameInputField;
    [SerializeField] private GameObject SettingsButton;
    [SerializeField] private GameObject GameNameText;
    [SerializeField] private GameObject GameVersionText;
    [SerializeField] private GameObject CloseSettings;
    [SerializeField] private GameObject ToggleFPS;
    [SerializeField] private Toggle SelToggleFPS;
    [SerializeField] private GameObject TogglePlayerCount;
    [SerializeField] private Toggle SelTogglePlayerCount;
    [SerializeField] private GameObject CreditsCanvas;
    [SerializeField] private GameObject CarlandChris;

    public void openSettings()
    {
        MultiPlayerButton.SetActive(false);
        PlayerNameInputField.SetActive(false);
        SettingsButton.SetActive(false);
        GameNameText.SetActive(false);
        GameVersionText.SetActive(false);
        CloseSettings.SetActive(true);
        ToggleFPS.SetActive(true);
        TogglePlayerCount.SetActive(true);
        CreditsCanvas.SetActive(true);
        CarlandChris.SetActive(true);
    }

    public void closeSettings()
    {
        MultiPlayerButton.SetActive(true);
        PlayerNameInputField.SetActive(true);
        SettingsButton.SetActive(true);
        GameNameText.SetActive(true);
        GameVersionText.SetActive(true);
        CloseSettings.SetActive(false);
        ToggleFPS.SetActive(false);
        TogglePlayerCount.SetActive(false);
        CreditsCanvas.SetActive(false);
        CarlandChris.SetActive(false);
    }

    public void Janne()
    {
        Application.OpenURL("https://www.instagram.com/janne_s_a/");
        Application.OpenURL("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
    }

    public void Josua()
    {
        Application.OpenURL("https://github.com/forest-cat");
    }

    public void Marcel()
    {
        Application.OpenURL("https://github.com/mine-ing");
    }


    public void ToggleFPSFunction(bool toggleState)
    {
        if (toggleState)
        {
            PlayerPrefs.SetString("showFPS", "true");
            PlayerPrefs.Save();
        }
        if (!toggleState)
        {
            PlayerPrefs.SetString("showFPS", "false");
            PlayerPrefs.Save();
        }
    }

    public void TogglePlayerCountFunction(bool toggleState)
    {
        if (toggleState)
        {
            PlayerPrefs.SetString("showPlayerCount", "true");
            PlayerPrefs.Save();
        }
        if (!toggleState)
        {
            PlayerPrefs.SetString("showPlayerCount", "false");
            PlayerPrefs.Save();
        }
    }

    void Update()
    {
        if(PlayerPrefs.GetString("showFPS") == "true")
        {
            SelToggleFPS.isOn = true;
        }
        else
        {
            SelToggleFPS.isOn = false;
        }

        if(PlayerPrefs.GetString("showPlayerCount") == "true")
        {
            SelTogglePlayerCount.isOn = true;
        }
        else
        {
            SelTogglePlayerCount.isOn = false;
        }
    }

}
