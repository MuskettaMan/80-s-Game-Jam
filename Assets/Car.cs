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
    #endregion

    #region Unity Methods
    void Start() {

    }

    void Update() {
        if (Input.GetKey(KeyCode.W)) {
            currentSpeed = Mathf.Lerp(currentSpeed, acceleratedSpeed, Time.deltaTime * accelerationSpeed);
        } else if (Input.GetKey(KeyCode.S)) {
            currentSpeed = Mathf.Lerp(currentSpeed, deceleratedSpeed, Time.deltaTime * accelerationSpeed);
        } else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) {
            currentSpeed = Mathf.Lerp(currentSpeed, defaultSpeed, Time.deltaTime * accelerationSpeed);
        }

        transform.localPosition += transform.forward * currentSpeed * Time.deltaTime; 
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion
}
