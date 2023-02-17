using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] testImgs; //�׽�Ʈ�� �� �̹���
    public int count = 10; //�ϴ� 10���� ī��Ʈ�ϱ�
    private List<GameObject> gameObject = new List<GameObject>();

    void Start()
    {
        for(int i=0; i<count; i++) {
            SpawnImg();
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position; //���� ������

        float posX = basePosition.x;
        float posY = basePosition.y + Random.Range(-3f, 3f);
        float posZ = 0;

        Vector3 spawnPos = new Vector3(posX, posY, posZ);
        
        return spawnPos;
    }

    private void SpawnImg()
    {
        int seletion = Random.Range(0, testImgs.Length);
        GameObject selectImg = testImgs[seletion];
        Vector3 spawnPos = GetRandomPosition(); //������ġ �Լ�

        GameObject instance = Instantiate(selectImg, spawnPos,Quaternion.identity);
        gameObject.Add(instance);
    }

}
