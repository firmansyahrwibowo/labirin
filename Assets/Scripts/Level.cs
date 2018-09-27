using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    public int Id;
    public GameObject Labirin;
    public bool IsClear;
    public int Stage;
    public Transform BallDefaultPosition;
}
