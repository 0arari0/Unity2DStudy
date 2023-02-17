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
            vx = speed; //오른쪽 키가 눌리면 오른쪽으로 나가아가는 이동량 넣기
            leftFlag = false;
        }
    }
}
