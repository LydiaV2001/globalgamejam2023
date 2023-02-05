using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _playerRigidbody;
    
    private Vector2 _movementInput;
    
    public float playerSpeed = 3;

    public Animator animator;

    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        _playerRigidbody.velocity = _movementInput.normalized * playerSpeed;

        animator.SetFloat("speed", Mathf.Abs(_movementInput.x) + Mathf.Abs(_movementInput.y));
    }
    
    void OnMove(InputValue movementValue) {
        _movementInput = movementValue.Get<Vector2>();
        
        if (_movementInput.x < 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
        
        

    }
}
