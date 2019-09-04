using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBoost : MonoBehaviour {

    private CarMovement carMovement;

    [SerializeField] private float boostSpeed;
    [SerializeField] private float boostGaugeIncrease;
    [SerializeField] private float boostGaugeDecrease;
    [SerializeField] private InputManager inputManager;

    private float boostGauge = 0;

    public bool Boosting {
        get; private set;
    }

    private void Awake() {
        carMovement = GetComponent<CarMovement>();

        inputManager.boostButtonDown += OnBoostButtonDown;
    }

    private void Update() {
        if (Boosting) {
            carMovement.SetTargetSpeed(boostSpeed);
            boostGauge -= boostGaugeDecrease;

            Boosting = boostGauge > 0;
        } else {
            boostGauge += boostGaugeIncrease;
        }
        
        boostGauge = Mathf.Clamp01(boostGauge);
    }

    private void OnBoostButtonDown() {
        if (boostGauge >= 1) {
            Boosting = true;
        }
    }

}
