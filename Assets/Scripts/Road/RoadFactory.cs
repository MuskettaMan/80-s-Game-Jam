using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RoadFactory : ScriptableObject {

    [SerializeField] private Road prefab;

    private Stack<Road> pool;

    public Road Get() {
        if (pool == null) {
            pool = new Stack<Road>();
        }

        if (pool.Count > 0) {
            var instance = pool.Pop();
            instance.gameObject.SetActive(true);
            return instance;
        }

        Road clone = Instantiate(prefab);
        return clone;
        
    }

    public void Reclaim(Road road) {
        if (pool == null) {
            pool = new Stack<Road>();
        }

        road.gameObject.SetActive(false);
        pool.Push(road);
    }

}
