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
                GameObject.Instantiate(enemyBulletNonBreakable, firePoint.position, firePoint.rotation);
                GameObject.Instantiate(enemyBulletNonBreakable, firePoint2.position, firePoint2.rotation);
            }
            if (changeProjectile == false)
            {
                GameObject.Instantiate(enemyBulletBreakable, firePoint.position, firePoint.rotation);
                GameObject.Instantiate(enemyBulletBreakable, firePoint2.position, firePoint2.rotation);
            }
        }
        else if (hasTwoFirePoints == false)
        {
            if (changeProjectile == true)
            {
                GameObject.Instantiate(enemyBulletNonBreakable, firePoint.position, firePoint.rotation);
            }
            if (changeProjectile == false)
            {
                GameObject.Instantiate(enemyBulletBreakable, firePoint.position, firePoint.rotation);
            }
        }
    }
}