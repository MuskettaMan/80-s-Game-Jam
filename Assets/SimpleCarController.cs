using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarController : MonoBehaviour {

    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float defaultSpeed = .3f;
    public float steeringStrength = .3f;

    public void ApplyLocalPositionToVisuals(WheelCollider collider) {
        if (collider.transform.childCount == 0) {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        if (collider.name.Equals("FrontLeftWheel") || collider.name.Equals("FrontRightWheel")) { // This is a really crude fix, but we dont need the back wheels to turn and I mean we've got 2 days so...
            visualWheel.transform.position = position;
        }
        visualWheel.transform.rotation = rotation;

    }

    private void FixedUpdate() {
        float motor = maxMotorTorque * (Input.GetAxis("Vertical") + defaultSpeed);
        float steering = maxSteeringAngle * (Input.GetAxis("Horizontal") * steeringStrength);

        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }

            if (axleInfo.motor) {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }

}

[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}
