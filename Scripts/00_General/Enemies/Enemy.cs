using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    [HideInInspector] public AudioManager audioManager;

    public int damage;

    public int maxHealth;
    private int currentHealth;

    public int moveSpeed;

    private bool isTouchingWall;

    private void Start()
    {
        isTouchingWall = false;
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
    }

    public void HurtEnemy(int damage)
    {
        audioManager.EnemyDamageAudio();
        currentHealth -= damage;
        EnemyDeath();
    }

    public bool EnemyDeath()
    {
        //Destroy enemy object when its health is 0
        if (currentHealth <= 0)
        {
            audioManager.EnemyDeathAudio();

            explosionParticle.transform.parent = null;
            explosionParticle.Play();
            //areEnemiseDead.DestroyedCondition(gameObject);
            gameObject.SetActive(false);
            return true;
        }
        else return false;
    }

    public int CurrentHealth()
    {
        return currentHealth;
    }

    public int SetCurrentHealth()
    {
        currentHealth = maxHealth;
        return currentHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            isTouchingWall = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            isTouchingWall = false;
        }
    }

    public bool IsTouchingWall()
    {
        if (isTouchingWall)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
