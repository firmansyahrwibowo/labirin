using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkselerometerControllerManager : MonoBehaviour
{
    Rigidbody2D rigid;
    [SerializeField]
    private AkselerometerController _Controller;
    [SerializeField]
    private Transform _Labirin;
    public GameObject _Ball;
    [SerializeField]
    bool _IsActive;

    private void Start()
    {
        rigid = _Ball.GetComponent<Rigidbody2D>();
    }

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

    void FixedUpdate()
    {
        if (!_IsActive)
            return;

        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            // Player movement in desktop devices
            // Definition of force vector X and Y components
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            // Building of force vector
            Vector3 _Movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
            // Adding force to rigidbody
            rigid.AddForce(_Movement * _Controller.speed * Time.deltaTime);
            //rigid.AddForce(_Movement * _Controller.speed);
        }
        else
        {
            // Player movement in mobile devices
            // Building of force vector 
            Vector3 _Movement = new Vector3(Input.acceleration.x, Input.acceleration.y, 0.0f);
            // Adding force to rigidbody
            rigid.AddForce(_Movement * _Controller.speed * Time.deltaTime);
        }

    }
}
