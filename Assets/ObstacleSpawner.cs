using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
    #region Public Fields
    #endregion

    #region Private Fields
    [SerializeField] private List<GameObject> obstaclePrefabs;
    [SerializeField] private float spawnTimeInterval;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceBetweenPaths;

    private List<GameObject> spawnedObstacles;
    private float timer = 0;
    private CarMove car;
    #endregion

    #region Unity Methods
    private void Start() {
        spawnedObstacles = new List<GameObject>();
        car = target.GetComponent<CarMove>();
    }

    private void Update() {
        var pos = new Vector3();
        pos.z = target.position.z;
        transform.position = pos + new Vector3(0, 0, 100);

        timer += Time.deltaTime;
        if (timer * car.currentSpeed >= spawnTimeInterval) {
            timer -= spawnTimeInterval;

            if (Time.time < 20) {
                InstantiateObstacle(false);
            }

            if (Time.time > 20) {
                InstantiateObstacle(true);
            }
        }
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods

    private void InstantiateObstacle(bool twice) {
        var clone = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)]);
        clone.transform.position = transform.position;
        int random = Random.Range(-1, 2);
        clone.transform.position += new Vector3(distanceBetweenPaths * random, .5f, 0);

        spawnedObstacles.Add(clone);
        if (twice) {
            var anotherClone = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)]);
            anotherClone.transform.position = transform.position;
            int anotherRandom;
            do {
                anotherRandom = Random.Range(-1, 2);
            } while (anotherRandom == random);
            anotherClone.transform.position += new Vector3(distanceBetweenPaths * anotherRandom, .5f, 0);

            spawnedObstacles.Add(anotherClone);
        }
    }
    #endregion
}
