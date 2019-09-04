using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    [SerializeField] private string horizontalAxisName;
    [SerializeField] private string verticalAxisName;
    [SerializeField] private string leftButtonName;
    [SerializeField] private string rightButtonName;
    [SerializeField] private string boostButtonName;

    public Action<float> verticalAxis;
    public Action<float> horizontalAxis;
    public Action leftButtonDown;
    public Action rightButtonDown;
    public Action boostButtonDown;


    private void Update() {
        horizontalAxis?.Invoke(Input.GetAxis(horizontalAxisName));
        verticalAxis?.Invoke(Input.GetAxis(verticalAxisName));

        ButtonDown(leftButtonName, leftButtonDown);
        ButtonDown(rightButtonName, rightButtonDown);
        ButtonDown(boostButtonName, boostButtonDown);
    }

    private void ButtonDown(string name, Action buttonDown) {
        if (Input.GetButtonDown(name)) {
            buttonDown?.Invoke();
        }
    }

}
