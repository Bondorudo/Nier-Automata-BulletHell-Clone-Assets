using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private int[][] enemyYposArray = new int[3][];
    
    int yPosIndex;
    int yPos;

    public GameObject enemyPrefab;
    public Transform spawnPos;

    [Range(1,3)]
    public int enemiesInWave;


    private void Start()
    {
        enemyYposArray[0] = new int[] { 0 };
        enemyYposArray[1] = new int[] { -2, 2 };
        enemyYposArray[2] = new int[] { -3, 0, 3 };
    }

    public void SpawnEnemyWave()
    {
        yPosIndex = 0;

        for (int i = 0; i < enemiesInWave; i++)
        {
            yPos = enemyYposArray[enemiesInWave - 1][yPosIndex];

            Vector3 spawn = new Vector3(spawnPos.position.x, yPos, spawnPos.position.z);
            enemy = Instantiate(enemyPrefab, spawn, enemyPrefab.transform.rotation);

            yPosIndex++;
        }
    }
}
