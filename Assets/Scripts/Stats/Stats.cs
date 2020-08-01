using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour
{
    protected int _health;
    
    protected UnityEvent Hit;
    protected UnityEvent Death;
    
    public void ApplyDamage(int damage)
    {
        if (damage >= _health)
        {
            _health = 0;
            //Событие убийства
            Death.Invoke();
        }
        else
        {
            _health -= damage;
            //Событе нанесения дамага
            Hit.Invoke();
        }
    }
}
