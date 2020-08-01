using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed { get; set; }
    public float LifeTime { get; set; }
    public  int Damage { get; set; }
    
    private void Update()
    {
        CheckLifeTime();
        MoveBullet();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.CheckEnemy(other, out EnemyStats enemy))
        {
            enemy.ApplyDamage(Damage);
        }

        Destroy(gameObject);
    }
    
    //---------------------------------------------//

    private void CheckLifeTime()
    {
        LifeTime -= Time.deltaTime;
        if (LifeTime <= 0)
            Destroy(gameObject);
    }
    
    private void MoveBullet() => transform.Translate(Vector3.forward * Speed * Time.deltaTime);

    public void SetBulletParametrs(float speed, float lifeTime, int damage)
    {
        Speed = speed;
        LifeTime = lifeTime;
        Damage = damage;
    }
    
}
