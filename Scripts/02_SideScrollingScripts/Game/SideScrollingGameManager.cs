using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollingGameManager : MonoBehaviour
{
    private GameManager gm;
    private EnemySpawner enemySpawner;
    private AreAllEnemiesDead areAllEnemiesDead;

    private int enemiesKilled;
    public int enemiesToBeKilled = 20;

    private bool isBossDead;
    private bool isWaveOver;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        enemySpawner = GameObject.FindWithTag("GameManager").GetComponent<EnemySpawner>();
        areAllEnemiesDead = GameObject.FindWithTag("GameManager").GetComponent<AreAllEnemiesDead>();
        StartCoroutine(SpawnEnemies());
        enemiesKilled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        enemiesKilled = areAllEnemiesDead.enemiesKilled;

        if (areAllEnemiesDead.listOfEnemies.Count == 0 && enemiesKilled >= enemiesToBeKilled)
        {
            // TODO: SPAWN BOSS
        }

        if (isBossDead)
        {
            // TODO: WIN LEVEL
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (enemiesKilled < enemiesToBeKilled)
        {
            while (areAllEnemiesDead.listOfEnemies.Count <= 0)
            {
                enemySpawner.SpawnEnemyWave();
                areAllEnemiesDead.listOfEnemies.AddRange(GameObject.FindGameObjectsWithTag("SideScrollEnemy"));
            }
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(1f);
    }
}
