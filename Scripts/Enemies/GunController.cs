using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public BulletController enemyBulletNonBreakable;
    public BulletController enemyBulletBreakable;
    public Transform firePoint;

    public int damage = 1;
    public float bulletSpeed = 10;
    public float coolDownDefault = 0.1f;
    public float changeBulletTimer;
    float coolDown = 0;
    
    public bool changeProjectile = false;
    private bool canShoot;

    private void Start()
    {
        StartCoroutine(ShootEnum());
        canShoot = false;
    }

    public void Update()
    {
        coolDown += Time.deltaTime;

        if (canShoot == true)
        {
            Shoot();
        }
    }

    IEnumerator ShootEnum()
    {
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
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