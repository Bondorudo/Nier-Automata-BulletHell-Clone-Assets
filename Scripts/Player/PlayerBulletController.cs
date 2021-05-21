using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    private PlayerController player;

    private float speed;
    private float destroyBullet = 4;

    private int damageToGive;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        speed = player.bulletSpeed;
        damageToGive = player.damage;
    }

    // Update is called once per frame
    void Update()
    {
        //control projectile movement
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, destroyBullet);
    }

    // Player Bullets
    private void OnTriggerEnter(Collider collision)
    {
        // If Bullet hits walls destroy it
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "DamageWall")
        {
            Destroy(gameObject);
        }
        // If Bullet hits Shield destroy it
        if (collision.gameObject.tag == "Shield")
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
