using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    [SerializeField] private CarMovement carMovement;
    [SerializeField] private float distanceBetweenPaths;
    [SerializeField] private float spawnInterval;
    [SerializeField] private float spawnTimeDecrease;
    [SerializeField] private float minimumSpawnTime;
    [SerializeField] private float spawnDistance;
    [SerializeField] private GameObject obstaclePrefab;

    private float timer = 0;
    private int lastSpawnPath = 0;

    private void Update() {
        timer += Time.deltaTime;

        if (spawnInterval >= minimumSpawnTime) {
            spawnInterval -= spawnTimeDecrease;
        } else {
            spawnInterval = minimumSpawnTime;
        }

        if (timer >= spawnInterval) {
            timer -= spawnInterval;

            var clone = Instantiate(obstaclePrefab);
            var pos = new Vector3();
            pos.z = carMovement.DistanceTraveled + spawnDistance;
            int random;
            do {
                random = Random.Range(-1, 2);
            } while (random == lastSpawnPath);
            lastSpawnPath = random;
            pos.x = random * distanceBetweenPaths;
            pos.y = 0;
            clone.transform.position = pos;
        }
    }

}
