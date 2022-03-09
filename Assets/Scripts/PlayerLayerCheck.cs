using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLayerCheck : MonoBehaviour
{
    [SerializeField] private LayerMask Zone;
    private Collider2D coll;

    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (coll.IsTouchingLayers(Zone))
        {
            Debug.Log("zoooooneeeeee");
            Destroy(gameObject);
        }
    }
}
