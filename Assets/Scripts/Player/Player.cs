using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player
{
    private int _health = 100;
    
    private UnityEvent Hit;
    private UnityEvent PlayerDeath;
    
    public Player (int health, UnityEvent hit, UnityEvent playerDeath)
    {
        _health = health;
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
