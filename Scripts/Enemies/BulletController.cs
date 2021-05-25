using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float destroyBullet = 4;

    public float speed;
    public int damageToGive;


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
        if (collision.gameObject.layer == 10)
        {
            Destroy(gameObject);
        }
        // If Purple collides with player destroy purple and damage player
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
            Destroy(gameObject);
        }
    }
}

