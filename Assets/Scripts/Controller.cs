using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    bool _Tap, _SwipeLeft, _SwipeRight, _SwipeUp, _SwipeDown, _IsActive;
    bool _IsDragging = false, _DragBug = false;
    Vector2 _StartTouch, _SwipeDelta;

    
    private void Update()
    {
        if (!_IsActive)
            return;

        _Tap = _SwipeLeft = _SwipeRight = _SwipeUp = _SwipeDown = false;

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            _Tap = true;
            _IsDragging = true;

            _StartTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _IsDragging = false;
            _DragBug = false;
            Reset();
        }
        #endregion

        _SwipeDelta = Vector2.zero;
        if (_IsDragging) {
            if (Input.GetMouseButton(0))
            {
                _SwipeDelta = (Vector2)Input.mousePosition - _StartTouch;

                Debug.Log(_SwipeDelta.x+ " M : "+_SwipeDelta.magnitude+" ST :"+_StartTouch.x);
            }
        }


        if (_SwipeDelta.magnitude > 30)
        {
            float x = _SwipeDelta.x;
            float y = _SwipeDelta.y;

            if (x < 0)
            {
                _SwipeRight = true;
                _SwipeLeft = false;
            }
            else
            {
                _SwipeLeft = true;
                _SwipeRight = false;
            }
            
        }
    }

    private void Reset()
    {
        _StartTouch = Vector2.zero;
        _SwipeDelta = Vector2.zero;
    }

    public bool Tap { get { return _Tap; } }
    public Vector2 SwipeDelta { get { return _SwipeDelta; } }
    public bool SwipeLeft { get { return _SwipeLeft; } }
    public bool SwipeRight { get { return _SwipeRight; } }
    public bool SwipeUp { get { return _SwipeUp; } }
    public bool SwipeDown { get { return _SwipeDown; } }
    public bool IsActive
    {
        get { return _IsActive; }
        set { _IsActive = value; }
    }
}
