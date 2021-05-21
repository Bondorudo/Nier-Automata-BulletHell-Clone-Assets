using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 15;
    public float destroyBullet = 4;

    public int damageToGive = 1;


    void Update()
    {
        //control projectile movement
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, destroyBullet);
    }

    // Enemy Bullets
    private void OnCollisionEnter(Collision collision)
    {
        // If Bullet hits walls destroy it
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "DamageWall")
        {
            Destroy(gameObject);
        }
        // If Purple collides with player destroy purple and damage player
        if (gameObject.tag == "Purple" && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
            Destroy(gameObject);
        }
        // If Orange collides with player destroy orange and damage player
        if (gameObject.tag == "Orange" && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
            Destroy(gameObject);
        }

        // If Purple collides with player destroy purple
        if (gameObject.tag == "Purple" && collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        // If Orange collides with player destroy orange
        if (gameObject.tag == "Orange" && collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

        // If Purple collides with player destroy purple
        if (gameObject.tag == "Purple" && collision.gameObject.tag == "WinCondition")
        {
            Destroy(gameObject);
        }
        // If Orange collides with player destroy orange
        if (gameObject.tag == "Orange" && collision.gameObject.tag == "WinCondition")
        {
            Destroy(gameObject);
        }
    }

    // Player Bullets
    private void OnTriggerEnter(Collider collision)
    {
        // If Bullet hits walls destroy it
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "DamageWall")
        {
            Destroy(gameObject);
        }
        // If Player Bullet and Enemy collide deal damage to enemy and destroy bullet
        if (gameObject.tag == "PlayerBullet" && collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyManager>().HurtEnemy(damageToGive);
            Destroy(gameObject);
        }
        // If Player Bullet and Enemy collide deal damage to enemy and destroy bullet
        if (gameObject.tag == "PlayerBullet" && collision.gameObject.tag == "WinCondition")
        {
            collision.gameObject.GetComponent<EnemyManager>().HurtEnemy(damageToGive);
            Destroy(gameObject);
        }
        // If Player Bullet and Orange Enemy Bullet collide destroy both bullets
        if (gameObject.tag == "PlayerBullet" && collision.gameObject.tag == "Orange")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

