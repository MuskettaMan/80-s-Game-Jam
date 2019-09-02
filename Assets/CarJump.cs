using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarJump : MonoBehaviour {

    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;

    private bool isJumping = false;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping) {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent() {
        return null;
    }

}
