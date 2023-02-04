using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject cloneGates;

    private int _cloneCount;
    public  int clonesNeeded = 3;

    public void CloneCounter()
    {
        _cloneCount = _cloneCount + 1;

        if (_cloneCount >= clonesNeeded)
        {
            cloneGates.SetActive(true);
        }
    }


}
