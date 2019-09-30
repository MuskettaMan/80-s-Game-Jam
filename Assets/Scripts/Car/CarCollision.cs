using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour {

    [SerializeField] private string obstacleTag;
    [SerializeField] private GameOver gameOver;

    private bool collided = false;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == obstacleTag && !collided) {
            gameOver.Collided();
            collided = true;
        }
    }

}
