using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotater : MonoBehaviour {
    #region Public Fields
    #endregion

    #region Private Fields
    private float radius;
    private float speed;

    [SerializeField] private CarMovement car;
    private Vector3 angles;
    #endregion

    #region Unity Methods
    void Start() {
        radius = 0.2f;
        angles = transform.eulerAngles;
    }

    void Update() {
        speed = car.CurrentSpeed;
        angles.x += speed / radius;

        transform.eulerAngles = angles;
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion
}
