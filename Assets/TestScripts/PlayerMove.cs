using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 2;

    float vx = 0;
    float vy = 0;
    bool leftFlag = false;

    void Update()
    {
        vx = 0;
        vy = 0;

        if (Input.GetKey("right"))
        {
            vx = speed; //������ Ű�� ������ ���������� �����ư��� �̵��� �ֱ�
            leftFlag = false;
        }
    }
}
