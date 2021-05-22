﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private GameObject enemyBulletNonBreakable;
    [SerializeField] private GameObject enemyBulletBreakable;
    public Transform firePoint;

    public int damage = 1;
    public float bulletSpeed = 10;
    public float coolDownDefault = 0.1f;
    float coolDown = 0;
    
    public bool changeProjectile = false;


    public void Update()
    {
        coolDown += Time.deltaTime;
    }


    public void Shoot()
    {
        //A new projectile can be shot once coolDown reaches coolDownDefault
        if (coolDown > coolDownDefault)
        {
            if (changeProjectile == true)
            {
                GameObject.Instantiate(enemyBulletNonBreakable, firePoint.position, firePoint.rotation);
                coolDown = 0;
            }
            if (changeProjectile == false)
            {
                GameObject.Instantiate(enemyBulletBreakable, firePoint.position, firePoint.rotation);
                coolDown = 0;
            }
        }
    }
}