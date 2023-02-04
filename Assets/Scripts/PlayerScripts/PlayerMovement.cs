using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _playerRigidbody;

    public float growTime;
    public GameObject clone;
    public String plantButton = "Fire1";
    public float playerSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire1");
            StartCoroutine(StartGrow(_playerRigidbody.transform));
        }
    }

    void FixedUpdate()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        Vector2 inputVelocity = new Vector2(directionX, directionY).normalized;

        _playerRigidbody.velocity = inputVelocity * playerSpeed;
    }

    IEnumerator StartGrow(Transform growPosition)
    {
        Debug.Log("starting grow");
        yield return new WaitForSeconds(growTime);
        Debug.Log("instantiating");
        Instantiate(clone, transform);
    }
}
