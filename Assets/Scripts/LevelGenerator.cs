using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelGenerator : MonoBehaviour

{
    public bool generatingTerrain;
    public int genSeed;
    [SerializeField] private GameObject myChunk_0;
    [SerializeField] private GameObject myChunk_1;
    [SerializeField] private GameObject myChunk_2;
    [SerializeField] private GameObject myChunk_3;
    [SerializeField] private GameObject myChunk_4;
    [SerializeField] private GameObject myChunk_5;
    [SerializeField] private GameObject myChunk_6;
    [SerializeField] private GameObject myChunk_7;
    [SerializeField] private GameObject myChunk_8;
    [SerializeField] private GameObject myChunk_9;
    [SerializeField] private GameObject myChunk_10;
    [SerializeField] private GameObject myChunk_11;
    

    [SerializeField] private Transform generationPoint;
    [SerializeField] private int distanceBetweenMin;
    [SerializeField] private int distanceBetweenMax;

    private GameObject[] Chunks = new GameObject[6];
    private int counter = 0;
    private System.Random rand;
    private int beforeChunk;


    private float platformWidth;

    void Start()
    {
        
        Chunks[0] = myChunk_0 as GameObject;
        Chunks[1] = myChunk_1 as GameObject;
        Chunks[2] = myChunk_2 as GameObject;
        Chunks[3] = myChunk_3 as GameObject;
        Chunks[4] = myChunk_4 as GameObject;
        Chunks[5] = myChunk_5 as GameObject;
        //Chunks[5] = myChunk_5 as GameObject;

        transform.position = new Vector3(24.2f, 0, 0);
        Instantiate(Chunks[1], transform.position, Quaternion.identity);
        beforeChunk = 1;

    }

    void Update()
    {
        
        if (genSeed != 0 && counter < 1)
        {
            Debug.Log("GenSeed from LevelGenerator: " + genSeed.ToString());
            rand = new System.Random(genSeed);
            counter++;
        }



        if (transform.position.x < generationPoint.position.x)
        {
            int distanceBetween = rand.Next(distanceBetweenMin, distanceBetweenMax);
            int randomNumber = rand.Next(0, 6);
            platformWidth = Chunks[beforeChunk].GetComponent<BoxCollider>().size.x;
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, 0);
            Instantiate(Chunks[randomNumber], transform.position, Quaternion.identity);
            beforeChunk = randomNumber;
        }

        
    }
}