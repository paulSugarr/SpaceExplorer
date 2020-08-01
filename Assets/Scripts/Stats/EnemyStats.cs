using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyStats : Stats
{
    public EnemyStats(int health, UnityEvent hit, UnityEvent enemyDeath)
    {
        _health = health;
        Hit = hit;
        Death = enemyDeath;
    }
}
