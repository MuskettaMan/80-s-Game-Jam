using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

    [SerializeField] private float defaultSpeed,
        acceleratedSpeed,
        deceleratedSpeed,
        accelerationSpeed;

    public float CurrentSpeed {
        get; private set;
    }

    public float TargetSpeed {
        get; private set;
    }

    public float DistanceTraveled {
        get; private set;
    }

    private Rigidbody rb;

    [SerializeField] private InputManager inputManager;

    private void Awake() {
        rb = GetComponent<Rigidbody>();

        inputManager.verticalAxis += OnVerticalAxis;
    }

    private void Update() {
        Move();
        DistanceTraveled = transform.position.z;
    }

    private void Move() {

        CurrentSpeed = Mathf.Lerp(CurrentSpeed, TargetSpeed, Time.deltaTime * accelerationSpeed);

        rb.MovePosition(rb.position + new Vector3(0, 0, CurrentSpeed * Time.deltaTime));
    }

    private void OnVerticalAxis(float axis) {
        switch (axis) {
            case 0:
                TargetSpeed = defaultSpeed;
                break;
            case float val when val < 0:
                TargetSpeed = deceleratedSpeed;
                break;
            case float val when val > 0:
                TargetSpeed = acceleratedSpeed;
                break;
        }
    }

    public void SetTargetSpeed(float target) {
        TargetSpeed = target;
    }

}
