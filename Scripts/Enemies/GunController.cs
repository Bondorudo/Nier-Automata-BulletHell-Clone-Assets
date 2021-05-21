using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public BulletController enemyBulletNonBreakable;
    public BulletController enemyBulletBreakable;
    public Transform firePoint;

    public float bulletSpeed;
    public float coolDownDefault = 0.1f;
    public float changeBulletTimer;
    float coolDown = 0;
    
    public bool changeProjectile = false;

    /*
    private void Awake()
    {
        InvokeRepeating("Switch", 0, changeBulletTimer);
    }

    void Switch()
    {
        changeProjectile = !changeProjectile;
    }
    */

    public void Update()
    {
        coolDown += Time.deltaTime;

        Shoot();
    }

    public void Shoot()
    {
        //A new projectile can be shot once coolDown reaches coolDownDefault
        if (coolDown > coolDownDefault)
        {
            if (changeProjectile == true)
            {
                Instantiate(enemyBulletNonBreakable, firePoint.position, firePoint.rotation);
                coolDown = 0;
            }
            if (changeProjectile == false)
            {
                Instantiate(enemyBulletBreakable, firePoint.position, firePoint.rotation);
                coolDown = 0;
            }
        }
    }
}