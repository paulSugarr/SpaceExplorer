using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyStats : Stats
{
    private void Start()
    {
        Death += DestroySelf;
    }
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
