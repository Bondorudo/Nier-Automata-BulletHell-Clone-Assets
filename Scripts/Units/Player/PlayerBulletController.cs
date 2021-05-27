using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    private float destroyBullet = 4;
    public float bulletSpeed;
    public int damageToGive;


    // Update is called once per frame
    void Update()
    {
        //control projectile movement
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        Destroy(gameObject, destroyBullet);
    }

    private void OnTriggerEnter(Collider collision)
    {
        // If Bullet hits walls or shields destroy it
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "DamageWall" || collision.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }
        // If Bullet and Enemy collide deal damage to enemy and destroy bullet
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "BreakableWall" || collision.gameObject.tag == "WinCondition")
        {
            collision.gameObject.GetComponent<EnemyManager>().HurtEnemy(damageToGive);
            Destroy(gameObject);
        }
        // If Bullet and SideScroll Enemy collide deal damage and destroy bullet
        if (collision.gameObject.tag == "SideScrollEnemy")
        {
            collision.gameObject.GetComponent<EnemySideScroll>().HurtEnemy(damageToGive);
            Destroy(gameObject);
        }
    }
}
