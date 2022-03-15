using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsEnforcer : MonoBehaviour
{
    [SerializeField] private GameObject FPSCounter;
    [SerializeField] private GameObject PlayerCounter;

    void Start()
    {
        if (PlayerPrefs.GetString("showFPS") == "true")
        {
            FPSCounter.SetActive(true);
        }
        if (PlayerPrefs.GetString("showFPS") == "false")
        {
            FPSCounter.SetActive(false);
        }

        if (PlayerPrefs.GetString("showPlayerCount") == "true")
        {
            PlayerCounter.SetActive(true);
        }
        if (PlayerPrefs.GetString("showPlayerCount") == "false")
        {
            PlayerCounter.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
