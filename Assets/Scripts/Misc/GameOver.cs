using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour {

    [SerializeField] private CarMovement car;
    [SerializeField] private CarSideMovement carSide;

    public void Collided() {
        car.enabled = false;
        carSide.enabled = false;
        Camera.main.fieldOfView = 60;
        StartCoroutine(Restart());
    }

    public IEnumerator Restart() {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
    }

}
