using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip;
    public float jumpForce = 700f;

    private int jumpCount = 0;
    private bool isGrounded = false; //�ٴڿ� ��Ҵ���
    private bool isDead = false; //��� ����
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
        if (isDead) return; //��� �� ó���� �� �̻� ���� �ʰ� ����

        //Ű�� ������ �ִ� ���� Ƚ���� 2�� �������� �ʾҴٸ�
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            jumpCount++;
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();
        }
        //Ű���� ���� ���� ���� && �ӵ� y���� ����̸� ���� �ӵ��� ������
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
