using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    [SerializeField] private string horizontalAxisName;
    [SerializeField] private string verticalAxisName;

    public Action<float> verticalAxis;
    public Action<float> horizontalAxis;


    private void Update() {
        horizontalAxis?.Invoke(Input.GetAxis(horizontalAxisName));
        verticalAxis?.Invoke(Input.GetAxis(verticalAxisName));
    }

}
