using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySideScroll : Enemy
{
    private Rigidbody rb;

    [SerializeField] private float leftWall = 7;
    private bool hasEnteredFight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasEnteredFight)
        {
            Shooting();
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.x >= leftWall)
        {
            hasEnteredFight = false;
            Movement();
        }
        else
        {
            hasEnteredFight = true;
            StopMovement();
        }
    }

    private void Movement()
    {
        rb.velocity = (transform.forward * moveSpeed);
    }

    private void StopMovement()
    {
        rb.velocity = Vector3.zero;
    }

    private void Shooting()
    {

    }
}
