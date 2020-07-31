using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed { get; set; }
    public float MaxLifeTime { get; set; }
    
    private float _currentLifeTime;

    private void Update()
    {
        CheckLifeTime();
        MoveBullet();
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
    
    //---------------------------------------------//

    private void CheckLifeTime()
    {
        _currentLifeTime += Time.deltaTime;
        if (_currentLifeTime >= MaxLifeTime)
            Destroy(gameObject);
    }
    
    private void MoveBullet() => transform.Translate(Vector3.forward * Speed * Time.deltaTime); 
    
}
