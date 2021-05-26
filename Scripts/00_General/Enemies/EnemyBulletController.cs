using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    [HideInInspector] public float speed;
    [HideInInspector] public int damageToGive;

    private Vector2 moveDirection;

    private void OnEnable()
    {
        Invoke("DisableBullet", 4f);
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
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

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void DisableBullet()
    {
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
