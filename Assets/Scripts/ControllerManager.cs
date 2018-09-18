using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour {

    [SerializeField]
    private Controller _Controller;
    [SerializeField]
    private Transform _Labirin;
    private Vector2 _DesiredPosition;

    [SerializeField]
    float _Speed;

    bool _IsActive;

    private void Awake()
    {
        EventManager.AddListener<ControllerEvent>(ControllerHandler);
        EventManager.AddListener<ChangeLabirinControlEvent>(ChangeLabirin);
    }

    private void ChangeLabirin(ChangeLabirinControlEvent e)
    {
        _Labirin = e.Labirin;
    }

    private void ControllerHandler(ControllerEvent e)
    {
        _IsActive = e.IsActive;
        _Controller.IsActive = e.IsActive;
    }
    // Update is called once per frame
    void Update ()
    {
        if (!_IsActive)
            return;

        if (_Controller.SwipeLeft)
            _Labirin.transform.eulerAngles = new Vector3(_Labirin.transform.eulerAngles.x, _Labirin.transform.eulerAngles.y, _Labirin.transform.eulerAngles.z + _Speed);
        else if (_Controller.SwipeRight)
            _Labirin.transform.eulerAngles = new Vector3(_Labirin.transform.eulerAngles.x, _Labirin.transform.eulerAngles.y, _Labirin.transform.eulerAngles.z - _Speed);
       
    }
}
