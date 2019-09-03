using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour {

    private Image blackScreen;
    [SerializeField] private AnimationCurve fadeIn;
    [SerializeField] private AnimationCurve fadeOut;
    private float targetAlpha;

    private bool fadeInController = false;
    private bool fadeOutController = false;
    private float timer = 0.0f;

    private void Start() {
        blackScreen = GetComponent<Image>();
        timer = 0.0f;
    }

    private void Update() {
        Mathf.Clamp01(targetAlpha);

        var c = blackScreen.color;
        c.a = targetAlpha;
        blackScreen.color = c;
        if (fadeInController) {
            FadeIn();
        }

        if (fadeOutController) {
            FadeOut();
        }
    }

    public void FadeIn() {
        fadeInController = true;
        timer += Time.deltaTime;
        targetAlpha = fadeIn.Evaluate(timer);
        if (targetAlpha <= 0.01f) {
            fadeInController = false;
            timer = 0.0f;
        } 
    }

    public void FadeOut() {
        fadeOutController = true;
        timer += Time.deltaTime;
        targetAlpha = fadeOut.Evaluate(timer);
        if (targetAlpha >= 0.99f) {
            fadeOutController = false;
            timer = 0.0f;
        }
    }

}
