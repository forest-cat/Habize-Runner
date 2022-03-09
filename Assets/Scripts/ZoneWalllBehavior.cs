using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneWalllBehavior : MonoBehaviour
{

    void Update()
    {
        if(PlayerPrefs.GetString("isStarted") == "true")
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * 2;
        }
        
    }
}
