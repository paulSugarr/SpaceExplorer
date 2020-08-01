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

    protected float _shootCounter;
    protected bool CanShoot()
    {
        return _shootCounter >= timeBetweenShots;
    }
    protected void Start()
    {
        _shootCounter = timeBetweenShots;
    }
    protected void Update()
    {
        _shootCounter += Time.deltaTime;
    }

    public abstract void Shoot();
}
