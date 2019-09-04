using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarMove : MonoBehaviour {
    #region Public Fields
    public float boostGauge = 0.0f;
    public float currentSpeed;
    public bool canMove = true;
    #endregion

    #region Private Fields
    [SerializeField] private float defaultSpeed = 10;
    [SerializeField] private float acceleratedSpeed = 15;
    [SerializeField] private float deceleratedSpeed = 5;
    [SerializeField] private float accelerationSpeed = 3;
    [SerializeField] private float boostSpeed = 30;
    [SerializeField] private float boostGaugeIncrease = 0.1f;
    [SerializeField] private float boostGaugeDecrease = 0.1f;
    [SerializeField] private float distanceBetweenPaths;
    [SerializeField] private Image boostGaugeUI;
    [SerializeField] private TextMeshProUGUI scoreText;

    private Rigidbody rb;
    private Vector3 targetPosition;
    private int targetPath = 0;
    private bool boosting = false;

    private float defaultFov;
    private float score = 0;
    private float scoreToDisplay = 0;
    private bool isJumping = false;
    #endregion

    #region Unity Methods
    void Start() {
        rb = GetComponent<Rigidbody>();
        defaultFov = Camera.main.fieldOfView;
    }

    void Update() {
        if (!canMove)
            return;

        score += 5;

        if ((Input.GetKey(KeyCode.W) || Input.GetButton("Fire7")) && !boosting) {
            currentSpeed = Mathf.Lerp(currentSpeed, acceleratedSpeed, Time.deltaTime * accelerationSpeed);
        } else if ((Input.GetKey(KeyCode.S) || Input.GetButton("Fire6")) && !boosting) {
            currentSpeed = Mathf.Lerp(currentSpeed, deceleratedSpeed, Time.deltaTime * accelerationSpeed);
        } else if ((!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !boosting && !Input.GetButton("Fire7") && !Input.GetButton("Fire6"))) {
            currentSpeed = Mathf.Lerp(currentSpeed, defaultSpeed, Time.deltaTime * accelerationSpeed);
        }

        boostGauge = Mathf.Clamp01(boostGauge);
        boostGaugeUI.fillAmount = boostGauge;
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetButtonDown("Fire2")) && boostGauge >= 1) {
            boosting = true;
            score += 1000;
        }

        if (boosting) {
            currentSpeed = Mathf.Lerp(currentSpeed, boostSpeed, Time.deltaTime * accelerationSpeed);
            boostGauge -= boostGaugeDecrease;
            if (boostGauge <= 0) {
                boosting = false;
            }
        } else {
            boostGauge += boostGaugeIncrease;
        }

        //if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))) {
        //    StartCoroutine(WaitForJump());
        //}

        if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("Fire5")) {
            targetPath--;
        } else if (Input.GetKeyDown(KeyCode.D) || Input.GetButtonDown("Fire4")) {
            targetPath++;
        }

        targetPath = Mathf.Clamp(targetPath, -1, 1);

        targetPosition = rb.position;
        targetPosition.z += currentSpeed * Time.deltaTime;
        targetPosition.x = Mathf.Lerp(targetPosition.x, targetPath * distanceBetweenPaths, Time.deltaTime * 5);
        rb.MovePosition(targetPosition);

        Camera.main.fieldOfView = defaultFov + currentSpeed * 0.5f - 10;

        scoreToDisplay = Mathf.Lerp(scoreToDisplay, score, Time.deltaTime * 5);
        scoreText.text = "Score: " + (int)scoreToDisplay;
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private IEnumerator WaitForJump() {
        if (isJumping) {
            yield return new WaitForSeconds(1);
            isJumping = false;
        } else {
            rb.AddForce(Vector3.up * 300);
            isJumping = true;
        }
    }
    #endregion
}
