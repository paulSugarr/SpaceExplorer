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
    public GunController Gun;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCmera;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        mainCmera = FindObjectOfType<Camera>();
        
        Player = new Player(health, Hit, PlayerDeath);
    }

    private void Update()
    {
        SetMoveDirection();
        LookAtMousePoint();
        UseGun();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void SetMoveDirection()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"),0f ,Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;
    }

    private void MovePlayer() => playerRigidbody.velocity = moveVelocity; 

    private void LookAtMousePoint()
    {
        var cameraRay = mainCmera.ScreenPointToRay(Input.mousePosition);
        var groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            
            transform.LookAt(new Vector3(pointToLook.x, playerRigidbody.position.y, pointToLook.z));
        }
    }

    private void UseGun()
    {
        if (Input.GetMouseButtonDown(0))
            Gun.StartFire();
        
        if (Input.GetMouseButtonUp(0))
            Gun.StopFire();
    }
}
