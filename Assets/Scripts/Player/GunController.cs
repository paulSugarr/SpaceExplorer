using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private bool _isFiring;

    [SerializeField] private Bullet bullet;

    [SerializeField] private float bulletSpeed;
    [SerializeField] private float timeBetweenShots;
    [SerializeField] private float lifeTime;
    [SerializeField] private int damage;
    
    private float _shootCounter;

    [SerializeField] private Transform firePoint;

    private void Update()
    {
        UseGun();
        ShootingByTrigger();
    }

    public void StartShooting() => _isFiring = true;
    
    public void StopShooting() => _isFiring = false;
    
    private void UseGun()
    {
        if (Input.GetMouseButtonDown(0))
            StartShooting();
        
        if (Input.GetMouseButtonUp(0))
            StopShooting();
    }

    //---------------------------------------------//
    
    private void ShootingByTrigger()
    {
        if (_isFiring)
        {
            _shootCounter -= Time.deltaTime;
            if (_shootCounter <= 0)
            {
                _shootCounter = timeBetweenShots;
                Shoot();
            }
        }
        else
        {
            _shootCounter = 0;
        }
    }

    private void Shoot()
    {
        var newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        newBullet.SetBulletParametrs(bulletSpeed, lifeTime, damage);
    }
}
