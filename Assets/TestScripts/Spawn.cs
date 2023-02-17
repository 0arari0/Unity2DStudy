using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] testImgs; //테스트용 꽃 이미지
    public int count = 10; //일단 10개만 카운트하기
    private List<GameObject> gameObject = new List<GameObject>();

    void Start()
    {
        for(int i=0; i<count; i++) {
            SpawnImg();
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position; //현재 포지션

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
        Vector3 spawnPos = GetRandomPosition(); //랜덤위치 함수

        GameObject instance = Instantiate(selectImg, spawnPos,Quaternion.identity);
        gameObject.Add(instance);
    }

}
