using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour {

    [SerializeField] private Score score;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Update() {
        scoreText.text = ((int)score.ScoreCounter).ToString();
    }

}
