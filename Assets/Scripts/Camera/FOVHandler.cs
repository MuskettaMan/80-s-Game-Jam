using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVHandler : MonoBehaviour {

    [SerializeField] private CarMovement carMovent;
    private float baseFOV;

    private new Camera camera;

    private void Awake() {
        camera = GetComponent<Camera>();
        baseFOV = camera.fieldOfView;
    }

    private void Update() {
        camera.fieldOfView = baseFOV + carMovent.CurrentSpeed * 0.5f - 10;
    }

}
