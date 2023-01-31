using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SometimeRotate : MonoBehaviour
{
    int count = 0;
    int maxCount =10;
    int angle = 90;
    void Start()
    {
        count = 0;
    }

    void FixedUpdate()
    {
        count++;
        if(count >= maxCount)
        {
            this.transform.Rotate(0, 0, angle);
            count = 0;
        }
    }
}
