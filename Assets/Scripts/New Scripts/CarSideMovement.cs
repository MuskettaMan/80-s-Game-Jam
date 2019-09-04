using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSideMovement : MonoBehaviour {

    [SerializeField] private float distanceBetweenPaths;
    [SerializeField] private float pathChangeSpeed;
    [SerializeField] private InputManager inputManager;

    private float currentPos;
    private PathEnum targetPath;
    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        inputManager.rightButtonDown += OnRightButtonDown;
        inputManager.leftButtonDown += OnLeftButtonDown;
    }

    private void Update() {
        Move();

    }

    private void Move() {
        currentPos = Mathf.Lerp(currentPos, (float)targetPath * distanceBetweenPaths, Time.deltaTime * pathChangeSpeed);

        var pos = rb.position;
        pos.x = currentPos;

        rb.MovePosition(pos);
    }
    
    private void OnRightButtonDown() {
        IncreasePath();
    }

    private void OnLeftButtonDown() {
        DecreasePath();
    }

    private void IncreasePath() {
        targetPath++;
        targetPath = ClampPath();
    }

    private void DecreasePath() {
        targetPath--;
        targetPath = ClampPath();
    }

    private PathEnum ClampPath() {
        return (PathEnum)Mathf.Clamp((int)targetPath, (int)PathEnum.Left, (int)PathEnum.Right); // TargetPath is clamped between the outermost paths
    }

}
