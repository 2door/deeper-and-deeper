using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour {
    public List<Transform> spawners;
    public GameObject tilePrefab;
    public float distance;

    private float nextY;
    private int[][] patterns = new int[][] {
        new int[] {1, 1, 0, 0, 0, 0, 0, 1, 1},
        new int[] {0, 0, 0, 1, 1, 1, 0, 0, 0},
        new int[] {1, 0, 0, 0, 1, 0, 0, 0, 1}
    };

    void Start() {
        // Spawn initial platform
        SpawnPlatform(transform.position.y);
    }

    void FixedUpdate() {
        // Spawn new platform after camera moves;
        if(transform.position.y <= nextY) {
            SpawnPlatform(nextY);
        }
    }

    private void SpawnPlatform(float Y) {
        // Pick random pattern
        int pattern = Random.Range(0, patterns.Length);
        for(int i = 0; i < spawners.Count; i++) {
            if(patterns[pattern][i] == 1) {
                Vector3 instantiatePosition = new Vector3(spawners[i].position.x, Y, .0f);
                Instantiate(tilePrefab.transform, instantiatePosition, Quaternion.identity);
            }
        }
        nextY = Y - distance;
    }
}
