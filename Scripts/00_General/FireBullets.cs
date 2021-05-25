using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private int bulletsAmount = 10;
    public float bulletSpeed = 55;

    [SerializeField] private float startAngle = 90f, endAngle = 270f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 2f);   
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount; i++)
        {
            float bulDirZ = firePoint.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = firePoint.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirZ, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - firePoint.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = firePoint.position;
            bul.transform.rotation = firePoint.rotation;
            bul.SetActive(true);
            bul.GetComponent<EnemyBulletController>().SetMoveDirection(bulDir);

            angle += angleStep;
        }
    }
}
