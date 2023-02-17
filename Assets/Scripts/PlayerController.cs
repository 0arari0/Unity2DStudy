using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip;
    public float jumpForce = 700f;

    private int jumpCount = 0;
    private bool isGrounded = false; //바닥에 닿았는지
    private bool isDead = false; //사망 상태
    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private AudioSource playerAudio;

    void Start()
    {
        playerRigidbody= GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isDead) return; //사망 시 처리를 더 이상 하지 않고 종료

        //키를 누르며 최대 점프 횟수가 2에 도달하지 않았다면
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            jumpCount++;
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();
        }
        //키에서 손을 떼는 순간 && 속도 y값이 양수이면 현재 속도를 반으로
        else if (Input.GetKeyDown(KeyCode.Space) && playerRigidbody.velocity.y > 0)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }

        animator.SetBool("Grounded", isGrounded);
    }
    
    private void Die()
    {
        animator.SetTrigger("Die");
        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerRigidbody.velocity = Vector2.zero;
        isDead= true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Dead" && !isDead)
        {
            Die();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded= false;
    }
}
