﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLabirin : MonoBehaviour
{
    public float SpeedAndDirection;
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward*SpeedAndDirection);
    }
}
