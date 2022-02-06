using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class PlayerSelector : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;
    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        
    }


    void Update()
    {
        string selectedPlayerName = PlayerPrefs.GetString("selectedPlayerName");
        vcam.Follow = GameObject.Find(selectedPlayerName + "(Clone)").transform;
    }
}
