using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy
{
    private int _health;

    private UnityEvent Hit;
    private UnityEvent EnemyDeath;

    public Enemy(int health, UnityEvent hit, UnityEvent enemyDeath)
    {
        _health = health;
        Hit = hit;
        EnemyDeath = enemyDeath;
    }

    public void ApplyDamage(int damage)
    {
        if (damage >= _health)
        {
            _health = 0;
            //Событие убийства
            EnemyDeath.Invoke();
        }
        else
        {
            _health -= damage;
            //Событе нанесения дамага
            Hit.Invoke();
        }
    }
}
