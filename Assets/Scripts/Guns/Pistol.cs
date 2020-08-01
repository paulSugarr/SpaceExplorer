using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    protected override void Shoot()
    {
        var newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        newBullet.SetBulletParametrs(bulletSpeed, lifeTime, damage);
    }
}
