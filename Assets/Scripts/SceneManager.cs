using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    [SerializeField] private GameObject cloneGates;

    [SerializeField] private GameObject clock;

    [SerializeField] private Timer timer;

    [SerializeField] private int levelTime;

    [SerializeField] private GameObject info;

    [SerializeField] private GameObject gameOver;

    [SerializeField] private GameObject gameWon;

    private int _cloneCount;
    private int _cloneReceived;
    public  int clonesNeeded = 3;

    private void Start()
    {
        Invoke(nameof(StartGame), 3.0f);
    }

    public void CloneCounter()
    {
        _cloneCount = _cloneCount + 1;

        if (_cloneCount >= clonesNeeded)
        {
            cloneGates.SetActive(true);
        }
    }

    public void StartGame()
    {
        info.SetActive(false);
        player.SetActive(true);
        timer.timeValue = levelTime;
        clock.SetActive(true);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        clock.SetActive(false);
    }

    public void CloneReceived()
    {
        _cloneReceived = _cloneReceived + 1;

        if (_cloneReceived >= clonesNeeded)
        {
            gameWon.SetActive(true);
            clock.SetActive(false);
        }
    }

}
