using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {
    #region Public Fields
    #endregion

    #region Private Fields
    [SerializeField] private float defaultSpeed = 10;
    [SerializeField] private float acceleratedSpeed = 15;
    [SerializeField] private float deceleratedSpeed = 5;
    [SerializeField] private float accelerationSpeed = 3;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float distanceBetweenPaths;

    private Rigidbody rb;
    private Vector3 targetPosition;
    private int targetPath = 0;
    #endregion

    #region Unity Methods
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        if (Input.GetKey(KeyCode.W)) {
            currentSpeed = Mathf.Lerp(currentSpeed, acceleratedSpeed, Time.deltaTime * accelerationSpeed);
        } else if (Input.GetKey(KeyCode.S)) {
            currentSpeed = Mathf.Lerp(currentSpeed, deceleratedSpeed, Time.deltaTime * accelerationSpeed);
        } else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) {
            currentSpeed = Mathf.Lerp(currentSpeed, defaultSpeed, Time.deltaTime * accelerationSpeed);
        }


        if (Input.GetKeyDown(KeyCode.A)) {
            targetPath--;
        } else if (Input.GetKeyDown(KeyCode.D)) {
            targetPath++;
        }

        targetPath = Mathf.Clamp(targetPath, -1, 1);

        targetPosition = rb.position;
        targetPosition.z += currentSpeed * Time.deltaTime;
        targetPosition.x = Mathf.Lerp(targetPosition.x, targetPath * distanceBetweenPaths, Time.deltaTime * 5);
        rb.MovePosition(targetPosition);
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion
}
