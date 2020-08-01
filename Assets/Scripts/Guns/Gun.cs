using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Gun : MonoBehaviour
{
    [SerializeField] protected Bullet bullet;

    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected float timeBetweenShots;
    [SerializeField] protected float lifeTime;
    [SerializeField] protected int damage;
    [SerializeField] protected Transform firePoint;

    private bool _isFiring;
    private float _shootCounter;
    
    public void StartShooting() => _isFiring = true;
    
    public void StopShooting() => _isFiring = false;
    
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

    protected abstract void Shoot();
}
