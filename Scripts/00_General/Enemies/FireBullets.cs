using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{
    [Range(1, 4)]
    [SerializeField] private int firePointCount;
    public Transform firePoint;
    public int bulletsAmount = 10;
    public float bulletSpeed = 55;

    [SerializeField] private float startAngle = 180f, endAngleA = 90f;


    public void Fire()
    {
        float angleStepA = ((endAngleA - startAngle) / bulletsAmount);
        float angleA = startAngle;

        for (int i = 0; i <= bulletsAmount; i++)
        {
            float bulDirZ = firePoint.position.x + Mathf.Sin((angleA * Mathf.PI) / 180f);
            float bulDirY = firePoint.position.y + Mathf.Cos((angleA * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirZ, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - firePoint.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = firePoint.position;
            bul.transform.rotation = firePoint.rotation;
            bul.SetActive(true);
            bul.GetComponent<EnemyBulletController>().SetMoveDirection(bulDir);
            bul.transform.parent = null;

            angleA += angleStepA;
        }
    }
}
