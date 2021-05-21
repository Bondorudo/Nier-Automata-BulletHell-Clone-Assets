using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemy : MonoBehaviour
{
    private EnemyManager enemyManager;
    private PlayerController thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        enemyManager = GetComponent<EnemyManager>();
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyManager.Rotations();
    }

    private void FixedUpdate()
    {
        enemyManager.Movement();
    }
}
