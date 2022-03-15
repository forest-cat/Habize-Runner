using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoxObstacle : Photon.MonoBehaviour
{
    private Vector3 correctPlayerPos;
    private Quaternion correctPlayerRot;
    private Rigidbody2D rb;
    private Vector2 velocity;
    private float angularVelocity;

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
            rb.velocity = velocity;
            rb.angularVelocity = angularVelocity;
            //Debug.Log("Transform Position on !isMine: " + transform.position.x.ToString());
        }
        void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.isWriting)
            {
                // We own this player: send the others our data
                stream.SendNext(transform.position);
                stream.SendNext(transform.rotation);
                stream.SendNext(rb.velocity);
                stream.SendNext(rb.angularVelocity);

            }
            else
            {
                // Network player, receive data
                this.correctPlayerPos = (Vector3)stream.ReceiveNext();
                this.correctPlayerRot = (Quaternion)stream.ReceiveNext();
                velocity = (Vector2)stream.ReceiveNext();
                angularVelocity = (float)stream.ReceiveNext();
            }
        }
    }
}
