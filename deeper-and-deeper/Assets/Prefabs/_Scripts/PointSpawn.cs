using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawn : MonoBehaviour {
    public List<Transform> spawners;
    public Transform pointPrefab;
    public float distance;

    private float nextY;

    void Start() {
        // Spawn initial point
        SpawnPoint(transform.position.y);
    }

    void FixedUpdate() {
        // Spawn new platform after camera moves;
        if(transform.position.y <= nextY) {
            SpawnPoint(nextY);
        }
    }

    private void SpawnPoint(float Y) {
        int i = Random.Range(0, spawners.Count);
        Vector3 instantiatePosition = new Vector3(spawners[i].position.x, Y, .0f);
        Instantiate(pointPrefab, instantiatePosition, Quaternion.identity);
        nextY = Y - distance;
    }
}
