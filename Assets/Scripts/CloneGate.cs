using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CloneGate : MonoBehaviour
{
    [FormerlySerializedAs("sceneManager")] [SerializeField] private SceneManagerObject sceneManagerObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Clone"))
        {
            sceneManagerObject.CloneReceived();
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
