using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloneMovement : MonoBehaviour
{
    private Rigidbody2D _cloneRigidbody;
    private Rigidbody2D _playerReference;
    
    public Vector2 playerVelocity;
    public bool isBlush = false;

    private SpriteRenderer _cloneSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        _cloneRigidbody = GetComponent<Rigidbody2D>();
        //_cloneSprite = GetComponent<SpriteRenderer>();
        _playerReference = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
            _cloneRigidbody.velocity = _playerReference.velocity;
           // _cloneRigidbody.velocity = new Vector2(-_playerReference.velocity.x, -_playerReference.velocity.y);
        
    }

    
    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isBlush = true;
            _cloneSprite.color = new Color(1, 1, 1, 0.5f);
            _cloneRigidbody.velocity = new Vector2(0, 0);
            _cloneRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isBlush = false;
            _cloneSprite.color = new Color(1, 1, 1, 1f);
            _cloneRigidbody.constraints = RigidbodyConstraints2D.None;
            _cloneRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }*/
    
}
