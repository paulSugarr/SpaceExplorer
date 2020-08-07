using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiGun : Gun
{
    public override void Shoot()
    {
        if (CanShoot())
        {
            var newBullet1 = Instantiate(bullet, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 35, 0));
            var newBullet2 = Instantiate(bullet, firePoint.position, firePoint.rotation * Quaternion.Euler(0, -35, 0));
            var newBullet3 = Instantiate(bullet, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 0));
            newBullet1.SetBulletParametrs(bulletSpeed, lifeTime, damage, Owner);
            newBullet2.SetBulletParametrs(bulletSpeed, lifeTime, damage, Owner);
            newBullet3.SetBulletParametrs(bulletSpeed, lifeTime, damage, Owner);
            _shootCounter = 0;
        }

    }
}
