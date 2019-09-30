using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {
    #region Public Fields
    #endregion

    #region Private Fields
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 distance;
    [SerializeField] private float xAngle;
    [SerializeField] private float frequency;
    [SerializeField] private Vector3 maximumTranslationShake = Vector3.one * 0.5f;
    [SerializeField] private Vector3 maximumAngularShake = Vector3.one * 2f;

    private float seed;
    #endregion

    #region Unity Methods
    void Start() {
        seed = Random.value;
    }

    void Update() {
        Vector3 pos;
        pos = target.position + distance;

        transform.position = pos;

        transform.eulerAngles = new Vector3(xAngle, 0, 0);

        transform.localPosition += new Vector3(
            maximumTranslationShake.x * (Mathf.PerlinNoise(seed, Time.time * frequency) * 2 - 1),
            maximumTranslationShake.y * (Mathf.PerlinNoise(seed + 1, Time.time * frequency) * 2 - 1),
            maximumTranslationShake.z * (Mathf.PerlinNoise(seed + 2, Time.time * frequency) * 2 - 1)
        );

        transform.eulerAngles += new Vector3(
            maximumAngularShake.x * (Mathf.PerlinNoise(seed + 3, Time.time * frequency) * 2 - 1),
            maximumAngularShake.y * (Mathf.PerlinNoise(seed + 4, Time.time * frequency) * 2 - 1),
            maximumAngularShake.z * (Mathf.PerlinNoise(seed + 5, Time.time * frequency) * 2 - 1)
        );
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion
}
