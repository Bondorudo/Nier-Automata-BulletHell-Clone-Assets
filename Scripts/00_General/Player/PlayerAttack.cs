using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private AudioManager audioManager;

    [SerializeField] private GameObject playerBullet;
    [SerializeField] private Transform firePoint;

    [SerializeField] private float coolDownDefault = 0.1f;
    private float coolDown = 0;

    [SerializeField] private float bulletSpeed = 25;
    [SerializeField] private int bulletDamage = 1;


    void Start()
    {
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
    }

    void Update()
    {
        coolDown += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (coolDown > coolDownDefault)
        {
            PlayerBulletController bullet = Instantiate(playerBullet, firePoint.position, firePoint.rotation).GetComponent<PlayerBulletController>();
            bullet.damageToGive = bulletDamage;
            bullet.bulletSpeed = bulletSpeed;
            audioManager.PlayerProjectileAudio();
            coolDown = 0;
        }
    }
}
