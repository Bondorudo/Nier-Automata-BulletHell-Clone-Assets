using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float speed = 200f;
    [HideInInspector] public int damageToGive = 1;

    public Vector2 moveDirection;

    private void OnEnable()
    {
        Invoke("DisableBullet", 40f);
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
            gameObject.SetActive(false);
        }
        // If Purple collides with player destroy purple and damage player
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
            gameObject.SetActive(false);
        }
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void DisableBullet()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
