using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    private AudioManager audioManager;

    private float destroyBullet = 4;

    public float bulletSpeed;
    public int damageToGive;

    private void Start()
    {
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //control projectile movement
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        Destroy(gameObject, destroyBullet);
    }

    // Player Bullets
    private void OnTriggerEnter(Collider collision)
    {
        // If Bullet hits walls or shields destroy it
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "DamageWall" || collision.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }
        // If Player Bullet and Enemy collide deal damage to enemy and destroy bullet
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "BreakableWall" || collision.gameObject.tag == "WinCondition")
        {
            collision.gameObject.GetComponent<EnemyManager>().HurtEnemy(damageToGive);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "SideScrollEnemy")
        {
            collision.gameObject.GetComponent<EnemySideScroll>().HurtEnemy(damageToGive);
            Destroy(gameObject);
        }

        // If Player Bullet and Orange Enemy Bullet collide destroy both bullets
        if (collision.gameObject.tag == "Orange")
        {
            audioManager.BulletCollisionAudio();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
