using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private GameObject enemyBulletNonBreakable;
    [SerializeField] private GameObject enemyBulletBreakable;
    public Transform firePoint;
    public Transform firePoint2;

    public int damage = 1;
    public float bulletSpeed = 10;
    
    public bool changeProjectile = false;
    public bool hasTwoFirePoints = false;


    public void Shoot()
    {
        if (hasTwoFirePoints == true)
        {
            if (changeProjectile == true)
            {
                BulletController bullet = Instantiate(enemyBulletNonBreakable, firePoint.position, firePoint.rotation).GetComponent<BulletController>();
                BulletController bullet2 = Instantiate(enemyBulletNonBreakable, firePoint2.position, firePoint2.rotation).GetComponent<BulletController>();
                bullet.damageToGive = damage;
                bullet.speed = bulletSpeed;
                bullet2.damageToGive = damage;
                bullet2.speed = bulletSpeed;
            }
            if (changeProjectile == false)
            {
                BulletController bullet = Instantiate(enemyBulletBreakable, firePoint.position, firePoint.rotation).GetComponent<BulletController>();
                BulletController bullet2 = Instantiate(enemyBulletBreakable, firePoint2.position, firePoint2.rotation).GetComponent<BulletController>();
                bullet.damageToGive = damage;
                bullet.speed = bulletSpeed;
                bullet2.damageToGive = damage;
                bullet2.speed = bulletSpeed;
            }
        }
        else if (hasTwoFirePoints == false)
        {
            if (changeProjectile == true)
            {
                BulletController bullet = Instantiate(enemyBulletNonBreakable, firePoint.position, firePoint.rotation).GetComponent<BulletController>();
                bullet.damageToGive = damage;
                bullet.speed = bulletSpeed;
            }
            if (changeProjectile == false)
            {
                BulletController bullet = Instantiate(enemyBulletBreakable, firePoint.position, firePoint.rotation).GetComponent<BulletController>();
                bullet.damageToGive = damage;
                bullet.speed = bulletSpeed;
            }
        }
    }
}