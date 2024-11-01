using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    ShootingBahavior myShootingBahavior;

    Vector2 moveInput;
    Vector2 fireInput;

    Vector2 minBounds;
    Vector2 maxBounds;

    float moveSpeed = 6f;

    void Awake()
    {
        myShootingBahavior = GetComponent<ShootingBahavior>();
    }

    void Start()
    {
        BoundInclude();
    }

    void Update()
    {
       Movement();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if(myShootingBahavior != null)
        {
            myShootingBahavior.isFiring = value.isPressed;
        }
    }
    
    void Movement()
    {
        Vector2 playerVelocity = moveInput * moveSpeed * Time.deltaTime;
        
        Vector2 positionBound = new Vector2();
        positionBound.x = Mathf.Clamp(transform.position.x + playerVelocity.x, minBounds.x + 0.5f, maxBounds.x - 0.5f);
        positionBound.y = Mathf.Clamp(transform.position.y + playerVelocity.y, minBounds.y + 1f, maxBounds.y - 1f);
        transform.position = positionBound;
    }

    void BoundInclude()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    } 
}