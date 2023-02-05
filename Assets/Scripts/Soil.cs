using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{

    [SerializeField]
    private SceneManager sceneManager;
    private bool _canPlant = false;

    public GameObject soilGlow;
    
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private GameObject clonePrefab;
    // Start is called before the first frame update

    // Update is called once per frame

    private void Awake()
    {
        
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag.Equals("Player"))
            _canPlant = true;
        soilGlow.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag.Equals("Player") )
            _canPlant = false;
        soilGlow.SetActive(false);
    }

    void OnFire()
    {
        if (_canPlant)
        {
            var position = transform.position;
            Instantiate(clonePrefab, new Vector2(position.x, position.y), Quaternion.identity);
            sceneManager.CloneCounter();
            Destroy(gameObject);
        }
            
    }
}
