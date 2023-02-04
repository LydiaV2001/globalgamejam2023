using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _playerRigidbody;
    
    private Vector2 _movementInput;
    
    public float playerSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        _playerRigidbody.velocity = _movementInput.normalized * playerSpeed;
    }
    
    void OnMove(InputValue movementValue) {
        _movementInput = movementValue.Get<Vector2>();
    }
}
