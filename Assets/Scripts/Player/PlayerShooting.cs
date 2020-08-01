using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Gun _gun;


    public void Shoot()
    {
        _gun.Shoot();
    }
}
