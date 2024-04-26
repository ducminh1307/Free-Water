using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private GameObject spawnPointParent;
    [SerializeField] private Transform enemyParent;
    [SerializeField] private GameObject[] enemyPrefabs;
    private Transform[] spawnPoints;

    [Header(" Datas ")]
    [SerializeField] private float spawnTime;
    void Start()
    {
        spawnPoints = spawnPointParent.GetComponentsInChildren<Transform>();
        StartCoroutine(SpawnEnemyCoroutine());
    }
    void Update()
    {
        
    }

    IEnumerator SpawnEnemyCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int spawnIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
        int enemyIndex = UnityEngine.Random.Range(0, enemyPrefabs.Length);
        Vector2 spawnPosition = spawnPoints[spawnIndex].position;
        Instantiate(enemyPrefabs[enemyIndex], spawnPosition, Quaternion.identity, enemyParent);
    }
}
