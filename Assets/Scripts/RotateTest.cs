using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTest : MonoBehaviour
{
    public float angle = 90;
    void FixedUpdate()
    {
        this.transform.Rotate(0, 0, angle/100);
    }
}
