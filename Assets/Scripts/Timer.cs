using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [HideInInspector]
    public float timeValue;
    
    [SerializeField] private SceneManager sceneManager; 
    
    
    private TMP_Text _timerText;

    // Start is called before the first frame update
    void Awake()
    {
        _timerText = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
            sceneManager.GameOver();
            
        }

        DisplayTime(timeValue);
    }

    private void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        _timerText.text = $"{minutes:00}:{seconds:00}";
    }
}