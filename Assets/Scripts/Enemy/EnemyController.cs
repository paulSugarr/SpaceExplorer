using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Status enemyStatus;
    
    private UnityEvent Hit;
    private UnityEvent EnemyDeath;

    public Enemy Enemy;

    private void Start()
    {
        Enemy = new Enemy(health, Hit, EnemyDeath);
    }

    
    private void EnemyBehavior()
    {
        switch (enemyStatus)
        {
            case Status.Attack:
                break;
            
            case Status.Defense:
                break;
            
            case Status.Patrolling:
                break;
        }
    }

    enum Status
    {
        Attack,
        Defense,
        Patrolling
    }
}
