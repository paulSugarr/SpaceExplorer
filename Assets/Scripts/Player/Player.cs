using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private int _health = 100;
    public Rigidbody PlayerRigidbody { get; private set; }
    public float MoveSpeed { get; private set; }
    
    public Player (int health, float moveSpeed, Rigidbody playerRigidbody)
    {
        _health = health;
        MoveSpeed = moveSpeed;
        PlayerRigidbody = playerRigidbody;
    }

    public void ApplyDamage(int damage)
    {
        if (damage >= _health)
        {
            //Событие убийства
            _health = 0;
        }
        else
        {
            _health -= damage;
            //Событе нанесения дамага
        }
    }
}
