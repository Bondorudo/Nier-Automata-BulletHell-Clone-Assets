using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bulletPoolInstance;
    private FireBullets fire;

    private GameObject bul;
    [SerializeField] private GameObject pooledPurpleBullet;
    [SerializeField] private GameObject pooledOrangeBullet;
    [Range(1,3)]
    [SerializeField] private int bulletType;
    [SerializeField] private int bulletAlternate = 2;
    private bool notEnoughtBulletsInPool = true;

    private List<GameObject> bullets;

    //public float bulletSpeed;

    private void Awake()
    {
        bulletPoolInstance = this;
        bullets = new List<GameObject>();
        fire = GetComponent<FireBullets>();
    }

    public GameObject GetBullet()
    {
        if (bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }

        if (notEnoughtBulletsInPool)
        {
            if (bulletType == 1)
            {
                // Instantiate purple
                bul = Instantiate(pooledPurpleBullet, fire.firePoint);
            }
            else if (bulletType == 2)
            {
                // Instantiate orange
                bul = Instantiate(pooledOrangeBullet, fire.firePoint);
            }
            if (bulletType == 3 && bullets.Count % bulletAlternate == 1)
            {
                // Instantiate orange and purple
                bul = Instantiate(pooledPurpleBullet, fire.firePoint);
            }
            else if(bulletType == 3 && bullets.Count % bulletAlternate != 1)
            {
                // Instantiate orange and purple
                bul = Instantiate(pooledOrangeBullet, fire.firePoint);
            }

            //bullets.Count
            //fire.bulletsAmount+1


            EnemyBulletController bulCon = bul.GetComponent<EnemyBulletController>();
            bulCon.speed = fire.bulletSpeed;
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }

        return null;
    }
}
