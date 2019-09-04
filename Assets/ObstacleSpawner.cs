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
    
    private float timer = 0;
    private CarMove car;

    private int spawnCounter = 3;
    #endregion

    #region Unity Methods
    private void Start() {
        car = target.GetComponent<CarMove>();
    }

    private void Update() {
        var pos = new Vector3();
        pos.z = target.position.z;
        transform.position = pos + new Vector3(0, 0, 100);

        spawnTimeInterval -= 0.0007f;

        timer += Time.deltaTime;
        if (timer >= spawnTimeInterval) {
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
        clone.transform.position = new Vector3(0, 0, car.transform.position.z + 100);
        int random = Random.Range(-1, 2);
        clone.transform.position += new Vector3(distanceBetweenPaths * random, .5f, 0);
        Destroy(clone, 60);

        if (twice) {
            var anotherClone = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)]);
            anotherClone.transform.position = new Vector3(0, 0, car.transform.position.z + 100);
            int anotherRandom;
            do {
                anotherRandom = Random.Range(-1, 2);
            } while (anotherRandom == random);
            anotherClone.transform.position += new Vector3(distanceBetweenPaths * anotherRandom, .5f, 0);
            Destroy(anotherClone, 60);
        }
        spawnCounter++;
    }
    #endregion
}
