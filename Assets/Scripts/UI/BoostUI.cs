using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostUI : MonoBehaviour {

    [SerializeField] private Image boostImage;
    [SerializeField] private CarBoost carBoost;

    private void Update() {
        boostImage.fillAmount = carBoost.BoostGauge;
    }

}
