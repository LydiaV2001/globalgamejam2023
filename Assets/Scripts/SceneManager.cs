using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private GameObject cloneGates;

    [SerializeField] private GameObject clock;

    [SerializeField] private Timer timer;

    [SerializeField] private int levelTime;

    [SerializeField] private GameObject info;

    private int _cloneCount;
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
        timer.timeValue = levelTime;
        clock.SetActive(true);
    }


}
