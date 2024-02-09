using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] monsterPrefabs; // ������ ���� ������ �迭
    public Transform[] spawnPoints; // ���� ���� ��ġ �迭

    void Start()
    {
        // ���� ����
        SpawnMonster();
    }

    void SpawnMonster()
    {
        // �������� ���� ������ ����
        GameObject selectedMonsterPrefab = monsterPrefabs[Random.Range(0, monsterPrefabs.Length)];

        // �������� ���� ��ġ ����
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // ���� ����
        Instantiate(selectedMonsterPrefab, spawnPoint.position, Quaternion.identity);
    }
}
