using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

    [SerializeField] private float defaultSpeed,
        acceleratedSpeed,
        deceleratedSpeed,
        accelerationSpeed;

    [SerializeField] private float currentSpeed, targetSpeed;

    private Rigidbody rb;

    [SerializeField] private InputManager inputManager;

    private void Awake() {
        rb = GetComponent<Rigidbody>();

        inputManager.verticalAxis += OnVerticalAxis;
    }

    private void Update() {
        Move();    
    }

    private void Move() {

        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime * accelerationSpeed);

        rb.MovePosition(rb.position + new Vector3(0, 0, currentSpeed * Time.deltaTime));
    }

    private void OnVerticalAxis(float axis) {
        switch (axis) {
            case 0:
                targetSpeed = defaultSpeed;
                break;
            case float val when val < 0:
                targetSpeed = deceleratedSpeed;
                break;
            case float val when val > 0:
                targetSpeed = acceleratedSpeed;
                break;
        }
    }

}
