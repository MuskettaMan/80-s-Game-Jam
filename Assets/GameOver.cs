using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour {

    [SerializeField] private ScreenFader screenFader;
    [SerializeField] private ScreenFader textFader;
    [SerializeField] private CarMove car;
    [SerializeField] private List<GameObject> turnMeOn = new List<GameObject>();

    private bool gameOver = false;
    private float a;

    private void Start() {
        textFader.gameObject.SetActive(false);
    }

    private void Update() {
        if (Input.GetButtonDown("Fire3") || Input.GetKeyDown(KeyCode.R) && !gameOver) {
            Collided();
            gameOver = true;
        }
    }

    public void Collided() {
        car.canMove = false;
        Camera.main.fieldOfView = 60;
        screenFader.FadeOut();
        StartCoroutine(WaitForScreenFade());
    }

    public void Restart() {
        SceneManager.LoadScene(0);
    }

    private IEnumerator WaitForScreenFade() {
        yield return new WaitForSeconds(1);
        foreach (GameObject go in turnMeOn) {
            go.SetActive(true);
        }
        textFader.gameObject.SetActive(true);
        textFader.FadeIn();
        yield return new WaitForSeconds(1);
        textFader.gameObject.SetActive(false);
    }

}
