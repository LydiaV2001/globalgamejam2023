using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _playerRigidbody;

    public bool isPlanted;
    public float growTime;

    public GameObject clone;

    public String plantButton = "Fire1";

    public enum PlayerStates
    {
        Walking,
        Planted
    };

    public PlayerStates currentPlayerState;

    public float playerSpeed = 3; 
    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Plant()
    {
        _playerRigidbody.velocity = new Vector2(0, 0);
        currentPlayerState = PlayerStates.Planted;
        
        // start coroutine
        StartCoroutine(StartGrow(_playerRigidbody.transform));
    }

    IEnumerator StartGrow(Transform growPosition)
    {
        Debug.Log("starting grow");
        yield return new WaitForSeconds(growTime);
        Debug.Log("instantiating");
        Instantiate(clone, transform);
    }

    void UnPlant()
    {
        currentPlayerState = PlayerStates.Walking;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (currentPlayerState)
        {
            case PlayerStates.Planted:
                
                break;
            case PlayerStates.Walking:
                float directionX = Input.GetAxisRaw("Horizontal");
                float directionY = Input.GetAxisRaw("Vertical");

                Vector2 inputVelocity = new Vector2(directionX, directionY).normalized;

                _playerRigidbody.velocity = inputVelocity * playerSpeed;

                break;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire1");
            if (currentPlayerState == PlayerStates.Walking)
            {
                // if player is on top of soil. 
                Plant();
            }
            else
            {
                UnPlant();
            }
            
        }
    }
}
