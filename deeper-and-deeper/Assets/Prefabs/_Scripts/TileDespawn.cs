using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDespawn : MonoBehaviour {
    private Transform target;

    void Start() {
        target = Camera.main.transform;
    }

    void Update() {
        float sqDist = (
            Mathf.Pow((target.position.x - transform.position.x), 2)
            + Mathf.Pow((target.position.y - transform.position.y), 2)
        );
        if(sqDist > 100) {
            Destroy(gameObject);
        }
    }
}
