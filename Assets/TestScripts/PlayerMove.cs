using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 2;
    bool leftFlag = false;

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 Position = transform.position;

        Position.x += x * speed * Time.deltaTime;
        Position.y += y * speed * Time.deltaTime;

        transform.position = Position;
    }
    void FixedUpdate()
    {
        //왼쪽 오른쪽 방향 바꾸기
        this.GetComponent<SpriteRenderer>().flipX = leftFlag;
    }
}
