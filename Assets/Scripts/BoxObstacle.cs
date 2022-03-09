using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoxObstacle : Photon.MonoBehaviour
{
    private Vector3 correctPlayerPos;
    private Quaternion correctPlayerRot;
    private Rigidbody2D rb;

    void Start()
    {
        if (!photonView.isMine)
        {
            rb = GetComponent<Rigidbody2D>();
            //Destroy(rb);
        }
        
    }


    void Update()
    {
        if (!photonView.isMine)
        {
            transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation, this.correctPlayerRot, Time.deltaTime * 5);
            //Debug.Log("Transform Position on !isMine: " + transform.position.x.ToString());
        }
        void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.isWriting)
            {
                // We own this player: send the others our data
                stream.SendNext(transform.position);
                stream.SendNext(transform.rotation);

            }
            else
            {
                // Network player, receive data
                this.correctPlayerPos = (Vector3)stream.ReceiveNext();
                this.correctPlayerRot = (Quaternion)stream.ReceiveNext();
            }
        }
    }
}
