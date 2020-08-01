using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerStats : Stats
{
    public PlayerStats(int health, UnityEvent hit, UnityEvent playerDeath)
    {
        _health = health;
        Hit = hit;
        Death = playerDeath;
    }
}
