using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    public override void Shoot()
    {
        if (CanShoot())
        {
            var newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            newBullet.SetBulletParametrs(bulletSpeed, lifeTime, damage, Owner);
            _shootCounter = 0;
        }

    }
}
