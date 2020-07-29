using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player
{
    private int _health = 100;
    public Rigidbody PlayerRigidbody { get; private set; }
    public float MoveSpeed { get; private set; }

    private UnityEvent Hit;
    private UnityEvent PlayerDeath;
    
    public Player (int health, float moveSpeed, Rigidbody playerRigidbody, UnityEvent hit, UnityEvent playerDeath)
    {
        _health = health;
        MoveSpeed = moveSpeed;
        PlayerRigidbody = playerRigidbody;
        Hit = hit;
        PlayerDeath = playerDeath;
    }

    public void ApplyDamage(int damage)
    {
        if (damage >= _health)
        {
            _health = 0;
            //Событие убийства
            PlayerDeath.Invoke();
        }
        else
        {
            _health -= damage;
            //Событе нанесения дамага
            Hit.Invoke();
        }
    }
}
