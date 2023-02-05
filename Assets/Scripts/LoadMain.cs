using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float waitTime;
    
    void Awake()
    {
        StartCoroutine(load());
    }

    IEnumerator load()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
