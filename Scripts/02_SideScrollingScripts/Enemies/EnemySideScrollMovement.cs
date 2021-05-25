using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySideScrollMovement : Enemy
{
    EnemySideScrollShooting shooting;

    // Start is called before the first frame update
    void Start()
    {
        shooting = GameObject.FindWithTag("SideScrollEnemy").GetComponent<EnemySideScrollShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        ParticleSystem particle = Instantiate(explosionParticle, transform.position, Quaternion.Euler(0f, 0f, 0f));
        particle.Play();
    }
}
