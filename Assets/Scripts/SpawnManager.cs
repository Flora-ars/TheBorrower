using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabCollectibles;
    private int indexPrefabCollect;

    private float posX = 5;
    private float posZ = 5;
    private float randomPosX, randomPosZ;

    private void Start()
    {
        InvokeRepeating("SpawnCollectibles", 1, 3);
    }

    private void Update()
    {
        GenerateRandomPos();
    }

    Vector3 GenerateRandomPos()
    {
        indexPrefabCollect = Random.Range(0, prefabCollectibles.Length);
        randomPosX = Random.Range(-posX, posX);
        randomPosZ = Random.Range(-posZ, posZ);
        Vector3 spawnPos = new Vector3(randomPosX, 1.5f, randomPosZ);
        
        return spawnPos;
    }

    void SpawnCollectibles()
    {
        Vector3 spawnPos = GenerateRandomPos();
        Instantiate(prefabCollectibles[indexPrefabCollect], spawnPos, Quaternion.identity);
    }
    

}
