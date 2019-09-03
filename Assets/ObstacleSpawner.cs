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
    #endregion

    #region Unity Methods
    private void Update() {
        var pos = new Vector3();
        pos.z = target.position.z;
        transform.position = pos + new Vector3(0, 0, 100);

        timer += Time.deltaTime;

        if (timer >= spawnTimeInterval) {
            timer -= spawnTimeInterval;

            InstantiateObstacle();
        }
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods

    private void InstantiateObstacle() {
        var clone = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)]);
        clone.transform.position = transform.position;
        clone.transform.position += new Vector3(distanceBetweenPaths * Random.Range(-1, 1), .5f, 0);
    }
    #endregion
}
