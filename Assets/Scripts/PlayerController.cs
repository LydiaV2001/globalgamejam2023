using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Takes and handles input and movement for a player character
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;

    private Vector2 _movementInput;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb;
    private readonly List<RaycastHit2D> _castCollisions = new List<RaycastHit2D>();

    private bool _canMove = true;

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() {
        if(_canMove) {
            if(_movementInput != Vector2.zero){
                
                bool success = TryMove(_movementInput);

                if(!success) {
                    success = TryMove(new Vector2(_movementInput.x, 0));
                }

                if(!success) {
                    success = TryMove(new Vector2(0, _movementInput.y));
                }
            } 
            
            if(_movementInput.x < 0) {
                _spriteRenderer.flipX = true;
            } else if (_movementInput.x > 0) {
                _spriteRenderer.flipX = false;
            }
        }
    }

    private bool TryMove(Vector2 direction) {
        if(direction != Vector2.zero) {
            var count = _rb.Cast(
                direction, 
                movementFilter, 
                _castCollisions, 
                moveSpeed * Time.fixedDeltaTime + collisionOffset);

            Debug.Log(count);
            
            if(count == 0){
                _rb.MovePosition(_rb.position + direction * (moveSpeed * Time.fixedDeltaTime));
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
        
    }

    void OnMove(InputValue movementValue) {
        _movementInput = movementValue.Get<Vector2>();
    }
    
    
    public void LockMovement() {
        _canMove = false;
    }
    
    public void UnlockMovement() {
        _canMove = true;
    }
}
