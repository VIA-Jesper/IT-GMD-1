using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logging : MonoBehaviour
{
    
    // order of execution can be found here: https://docs.unity3d.com/Manual/ExecutionOrder.html

    private void Awake()
    {
        Debug.Log(DateTime.Now.ToString("G") + ", AWAKE");
    }

    private void Start()
    {
        Debug.Log(DateTime.Now.ToString("G") + ", START");
    }

    private bool once = false;

    private void Update()
    {
        if (once == false)
        {
            Debug.Log(DateTime.Now.ToString("G") + ", UPDATE");
            once = true;
        }
    }
    
}
