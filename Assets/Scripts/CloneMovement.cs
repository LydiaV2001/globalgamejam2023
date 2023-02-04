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
    
    // Start is called before the first frame update
    void Start()
    {
        _cloneRigidbody = GetComponent<Rigidbody2D>();
        _playerReference = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isBlush)
        {
            _cloneRigidbody.velocity = _playerReference.velocity;
        }
    }

    /*
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isBlush = true;
        }
    }
    */
}
