using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    [SerializeField] private CarMovement carMovement;
    [SerializeField] private CarBoost carBoost;

    public float ScoreCounter {
        get; private set;
    }

    private void Awake() {
        carBoost.boostEnd += OnBoostEnd;
    }

    private void Update() {
        ScoreCounter += carMovement.CurrentSpeed;
    }

    private void OnBoostEnd() {
        ScoreCounter += 1000;
    }

}
