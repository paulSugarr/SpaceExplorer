using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour
{
    [SerializeField] protected int _health;
    
    protected event System.Action Hit;
    protected event System.Action Death;
    
    public void ApplyDamage(int damage)
    {
        if (damage >= _health)
        {
            _health = 0;
            //Событие убийства
            Death?.Invoke();
        }
        else
        {
            _health -= damage;
            //Событе нанесения дамага
            Hit?.Invoke();
        }
    }
}
