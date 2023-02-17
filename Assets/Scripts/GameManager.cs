using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //�̱����� �Ҵ��� ���� ����

    public bool isGameover = false;
    public Text scoreText;
    public GameObject gameoverUI;

    private int score = 0;

    void Awake()
    {
        //instance �� ����ִٸ� �� ���� �ڱ� �ڽ��� �Ҵ�
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("���� �� �� �̻��� ���ӸŴ����� �����մϴ�");
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (isGameover && Input.GetMouseButtonDown(0))
        {
            //���ӿ��� ���¿��� ����Ű ������ ���� �� �����
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void AddScore(int newScore)
    {
        if (!isGameover)
        {
            score += newScore;
            scoreText.text = "Score : " + score;
        }
    }
    public void OnPlayerDead()
    {
        isGameover = true;
        gameoverUI.SetActive(true);
    }
}
