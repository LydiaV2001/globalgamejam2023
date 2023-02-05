using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public List<String> levelList;

    public GameObject levelButton;
    
    public void PlayGame()
    {
        SceneManager.LoadScene("TestLevel");
    }
    
    public void PlayLevel(String LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
