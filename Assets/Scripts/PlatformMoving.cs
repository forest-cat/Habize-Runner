using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    [SerializeField] private int x1;
    [SerializeField] private int x2;
    [SerializeField] private int y1;
    [SerializeField] private int y2;
    [SerializeField] private int speed;
    [SerializeField] private int amount;

    private int counter1 = 0;
    private int counter2 = 0;
    void Update()
    {
        if (counter1 <= amount)
        {
            transform.position += new Vector3(x1, y1, 0) * Time.deltaTime * speed;
            counter1 += 1;
        }
        
        if (counter1 == amount)
        {
            counter2 = amount;
        }

        if(counter2 >= 0)
        {
            transform.position += new Vector3(x2, y2, 0) * Time.deltaTime * speed;
            counter2 -= 1;
        }
        if (counter2 == 0)
        {
            counter1 = 0;
        }
    }
}