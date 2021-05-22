using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Rigidbody enemyRb;
    private PlayerController thePlayer;
    private AreAllEnemiesDead areEnemiseDead;
    private GameManager gm;
    public GameObject enemy;
    private GunController gunController;

    public float speed = 3;
    public float damping = 5;
    public float rotationSpeed = 10f;

    public int health = 3;
    private int currentHealth;

    public bool canTakeDamage = true;
    public bool rotateClockwise = true;


    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerController>();
        gunController = GetComponent<GunController>();
        areEnemiseDead = GameObject.FindWithTag("GameManager").GetComponent<AreAllEnemiesDead>();
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        currentHealth = health;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            gunController.isTouchingWall = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            gunController.isTouchingWall = false;
        }
    }

    public void Shooting()
    {
        gunController.Shoot();
    }

    public void Movement()
    {
        enemyRb.velocity = (transform.forward * speed);
    }

    public void Rotations()
    {
        if (gm.isGameOver == false)
        {
            //Enemy rotates to look at the player
            var rotation = Quaternion.LookRotation(thePlayer.transform.position - enemy.transform.position);
            enemy.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
        }
    }

    public void ContinuousRotation()
    {
        if (rotateClockwise == true)
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
        else if (rotateClockwise == false)
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
    }

    //Enemy takes damage
    public void HurtEnemy(int damage)
    {
        if (canTakeDamage == true)
        {
            currentHealth -= damage;

            EnemyDeath();
        }
    }

    public void EnemyDeath()
    {
        //Destroy enemy object when its health is 0
        if (currentHealth <= 0)
        {
            areEnemiseDead.DestroyedCondition(gameObject);
            gameObject.SetActive(false);
        }
    }

    public int CurrentHealth()
    {
        return currentHealth;
    }
}
