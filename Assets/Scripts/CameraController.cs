using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float CamZoomPosition = -10f;
    public float CamOfSetX = 8f;
    public float CamOfSetY = 1f;

    private void Update (){
        transform.position = new Vector3(player.position.x+CamOfSetX, player.position.y+CamOfSetY, CamZoomPosition);
    }
}
