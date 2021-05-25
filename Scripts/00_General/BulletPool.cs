using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bulletPoolInstance;
    private FireBullets fire;

    [SerializeField] private GameObject pooledBullet;
    private bool notEnoughtBulletsInPool = true;

    private List<GameObject> bullets;

    //public float bulletSpeed;

    private void Awake()
    {
        bulletPoolInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
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
            GameObject bul = Instantiate(pooledBullet);
            EnemyBulletController bulCon = bul.GetComponent<EnemyBulletController>();
            bulCon.speed = fire.bulletSpeed;
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }

        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
