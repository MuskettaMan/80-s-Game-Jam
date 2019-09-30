using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CarBoost : MonoBehaviour {

    private CarMovement carMovement;

    [SerializeField] private float boostSpeed;
    [SerializeField] private float boostGaugeIncrease;
    [SerializeField] private float boostGaugeDecrease;
    [SerializeField] private InputManager inputManager;

    public Action boostStart;
    public Action boostEnd;

    public float BoostGauge {
        get; private set;
    } = 0;

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
            BoostGauge -= boostGaugeDecrease;
            BoostGauge = Mathf.Clamp01(BoostGauge);

            Boosting = BoostGauge > 0;
            if (BoostGauge <= 0) {
                Boosting = false;
                boostEnd?.Invoke();
            }
        } else {
            BoostGauge += boostGaugeIncrease;
            BoostGauge = Mathf.Clamp01(BoostGauge);
        }
        
    }

    private void OnBoostButtonDown() {
        if (BoostGauge >= 1) {
            Boosting = true;
            boostStart?.Invoke();
        }
    }

}
