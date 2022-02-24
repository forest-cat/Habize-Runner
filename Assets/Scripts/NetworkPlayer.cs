using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using TMPro;

public class NetworkPlayer : Photon.MonoBehaviour
{
    [SerializeField]private Text nameText;

    private Vector3 correctPlayerPos;
    private Quaternion correctPlayerRot;
    private GameObject LevelGenerator;
    private GameObject Player;
    private float pos;
    private PhotonView PV;
    private float old_pos_x;
    private int useSeed;
    private int seed;
    private GameObject scoreCounter;
    private float score;
    private Vector2 temp;
    private GameObject BGText;
    
    

    Rigidbody2D rb;

    [PunRPC]
    void Setting(int sharedSeed)
    {
        //useSeed = sharedSeed;
    }
    void CallSetting()
    {
        PV = GetComponent<PhotonView>();
        PV.RPC("Setting", PhotonTargets.AllBuffered, seed);
    }


    void Start()
    {
        scoreCounter = GameObject.Find("ScoreCounter");
        if (!photonView.isMine)
        {
            //PhotonNetwork.player.NickName = "Testos";
            nameText.text = photonView.owner.NickName;
            //nametext.text = "Hello";

        }

        seed = UnityEngine.Random.Range(1, 999999);
        LevelGenerator = GameObject.Find("LevelGenerator");
        //LevelGenerator.GetComponent<LevelGenerator>().generatingTerrain = false;
        //Debug.Log(generatingTerrain);
        if (photonView.isMine)
        {
            rb = GetComponent<Rigidbody2D>();
            rb.simulated = true;
            GetComponent<PlayerController>().enabled = true;
            
            PV = GetComponent<PhotonView>();
            
            if (PV.owner.isMasterClient)
            {
                ExitGames.Client.Photon.Hashtable setValue = new ExitGames.Client.Photon.Hashtable();
                setValue.Add("Seed", seed);
                PhotonNetwork.room.SetCustomProperties(setValue);
                //CallSetting();
                //Debug.Log(useSeed);

            }
            useSeed = (int)PhotonNetwork.room.CustomProperties["Seed"];

        }

        
        if (useSeed != 0)
        {
            //Debug.Log("The SEED i generated: " + seed.ToString());
            //Debug.Log("The SEED we will use: " + useSeed.ToString());
            LevelGenerator.GetComponent<LevelGenerator>().genSeed = useSeed;
        }
        if (!photonView.isMine)
        {
            BGText = transform.GetChild(1).transform.GetChild(1).transform.GetChild(0).gameObject;
        }

        old_pos_x = transform.position.x;

    }

   

    void Update()
    {
        
        if (!photonView.isMine)
        {

            if (old_pos_x > transform.position.x)
            {
                //Flips the Player into the direction he is walking
                transform.localScale = new Vector2(-1, 1);
                //BGText.transform.localScale = BGText.transform.localScale + new Vector3(-2, 0);
            }
            else if (old_pos_x < transform.position.x)
            {
                //Flips the Player into the direction he is walking
                transform.localScale = new Vector2(1, 1);
                //BGText.transform.localScale = BGText.transform.localScale + new Vector3(2, 0);
            }
            
        }
        

        //Setting old_pos_x to the current x position
        old_pos_x = transform.position.x;


        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject p in players)
        {
            if (!photonView.isMine)
            {
                //Debug.Log(p.GetPhotonView().owner.NickName.ToString() + ": " + p.transform.position.x.ToString());
                score = p.transform.position.x - scoreCounter.transform.position.x;
                if (p.transform.position.x == transform.position.x)
                {
                    nameText.text = "{" + Math.Round(score).ToString() + "} " + p.GetPhotonView().owner.NickName.ToString();
                }
                
            }

        }

        //Debug.Log(generatingTerrain);
        if (!photonView.isMine)
        {
            transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation, this.correctPlayerRot, Time.deltaTime * 5);
            Destroy(rb);
            //Debug.Log("Transform Position on !isMine: " + transform.position.x.ToString());
        }

        Player = GameObject.Find("Player_1(Clone)");
        if (photonView.isMine)
        {
            
                //Debug.Log("photonView.isMine: " + transform.position.x.ToString());


                //Will maybe be used Later DON'T REMOVE THIS ONE!!!
                /*
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                foreach (GameObject p in players)
                {
                    if (p.transform.position.x != transform.position.x && p.transform.position.x > transform.position.x)
                    {
                        LevelGenerator.GetComponent<LevelGenerator>().generatingTerrain = false;
                        //Debug.Log("POS: " + p.transform.position.x.ToString());
                        //Debug.Log(generatingTerrain);


                    }
                    else if (p.transform.position.x != transform.position.x && p.transform.position.x < transform.position.x)
                    {

                        LevelGenerator.GetComponent<LevelGenerator>().generatingTerrain = true;
                        //Debug.Log(generatingTerrain);
                    }
                    else if (PhotonNetwork.otherPlayers.Length + 1 == 1)
                    {
                        //LevelGenerator.GetComponent<LevelGenerator>().generatingTerrain = true;
                    }


                }
                */
            }

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
