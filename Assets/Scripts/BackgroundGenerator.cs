using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour

{
    [SerializeField] private GameObject backgroundImage;
    [SerializeField] private Transform generationPoint;

    private float platformWidth;

    void Start()
    {
        
    }
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            platformWidth = backgroundImage.GetComponent<BoxCollider>().size.x;
            transform.position = new Vector3(transform.position.x + platformWidth, transform.position.y, transform.position.z);
            Instantiate(backgroundImage, transform.position, transform.rotation);
        }
    }
}