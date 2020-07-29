using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private int health;
    [SerializeField]private float moveSpeed;
    [SerializeField]private Rigidbody playerRigidbody;

    public UnityEvent Hit;
    public UnityEvent PlayerDeath;
    
    public Player Player;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        Player = new Player(health, moveSpeed, playerRigidbody, Hit, PlayerDeath);
    }

    private void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"),0f ,Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * Player.MoveSpeed;
    }

    private void FixedUpdate()
    {
        Player.PlayerRigidbody.velocity = moveVelocity;
    }
}
