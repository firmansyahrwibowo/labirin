using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkselerometerController : MonoBehaviour
{
    public float speed = 1000;
    bool _IsActive;

    void Main()
    {
        // Preventing mobile devices going in to sleep mode 
        //(actual problem if only accelerometer input is used)
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Update()
    {
        if (!_IsActive)
        {
            return;
        }


    }
    public bool IsActive
    {
        get { return _IsActive; }
        set { _IsActive = value; }
    }
}
