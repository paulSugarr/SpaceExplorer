using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private bool isFiring;

    [SerializeField] private Bullet bullet;

    [SerializeField] private float bulletSpeed;
    [SerializeField] private float timeBetweenShots;
    private float shoutCounter;

    [SerializeField] private Transform firePoint;

    private void Update()
    {
        if (isFiring)
        {
            shoutCounter -= Time.deltaTime;
            if (shoutCounter <= 0)
            {
                shoutCounter = timeBetweenShots;
                var newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as Bullet;
                newBullet.speed = bulletSpeed;
            }
        }
        else
        {
            shoutCounter = 0;
        }
    }

    public void StartFire() => isFiring = true;
    
    public void StopFire() => isFiring = false;

}
