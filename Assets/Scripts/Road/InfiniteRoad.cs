using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;


public class InfiniteRoad : MonoBehaviour {
    #region Public Fields
    #endregion

    #region Private Fields
    [SerializeField] private RoadFactory roadFactory;
    [SerializeField] private float roadLength = 50;
    [SerializeField] private Transform followTarget;
    [SerializeField] private float loadedRoads;

    private List<Road> spawnedRoads = new List<Road>();
    #endregion

    #region Unity Methods
    void Start() {
        for (int i = (int)(loadedRoads / 2 - loadedRoads); i < (int)loadedRoads / 2; i++) {
            Road road = roadFactory.Get();
            road.name = "Road " + i;
            road.transform.position = new Vector3(0, 0, i * roadLength);
            spawnedRoads.Add(road);
        }
    }

    void Update() {
        for (int i = 0; i < spawnedRoads.Count; i++) {
            if (Vector3.Distance(spawnedRoads[i].transform.position, followTarget.position) > (loadedRoads / 2) * roadLength && spawnedRoads[i].transform.position.z - followTarget.position.z < 0) {
                roadFactory.Reclaim(spawnedRoads[i]);

                Road road = roadFactory.Get();
                road.transform.position = new Vector3(0, 0, spawnedRoads[i].transform.position.z + loadedRoads * roadLength);
                spawnedRoads[i] = road;
            }

        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(followTarget.position, (loadedRoads / 2) * roadLength);
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion
}
