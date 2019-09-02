using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;


public class InfiniteRoad : MonoBehaviour {
    #region Public Fields
    #endregion

    #region Private Fields
    [SerializeField] private GameObject prefab;
    [SerializeField] private float roadLength = 200;
    [SerializeField] private Transform followTarget;
    private GameObject[] pool = new GameObject[2];
    #endregion

    #region Unity Methods
    void Start() {
        for (int i = 0; i < pool.Length; i++) {
            var clone = Instantiate(prefab);
            clone.transform.position += new Vector3(0, 0, roadLength * i);
            clone.GetComponent<RoadMeshCreator>().GameUpdate();
            pool[i] = clone;
        }
    }

    void Update() {
        for (int i = 0; i < pool.Length; i++) {
            if (Vector3.Distance(pool[i].transform.position, followTarget.position) > 205 && (pool[i].transform.position.z - followTarget.position.z) < 0) {
                pool[i].transform.position += new Vector3(0, 0, roadLength * pool.Length);

                pool[i].GetComponent<RoadMeshCreator>().GameUpdate();
            }
        }
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion
}
