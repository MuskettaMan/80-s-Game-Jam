using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour {
    #region Public Fields
    #endregion

    #region Private Fields
    [SerializeField] private float speed;
    #endregion

    #region Unity Methods
    void Start() {

    }

    void Update() {
        transform.eulerAngles += new Vector3(0, speed, 0);
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion
}
