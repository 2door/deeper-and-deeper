using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour {
    public List<Transform> spawners;
    public Transform tilePrefab;
    public Transform obstaclePrefab;
    public float distance;

    private float nextY;
    private int[][] patterns = new int[][] {
        new int[] {1, 1, 0, 0, 0, 0, 0, 1, 1},
        new int[] {0, 0, 0, 1, 1, 1, 0, 0, 0},
        new int[] {1, 0, 0, 0, 1, 0, 0, 0, 1},
        new int[] {0, 0, 1, 1, 2, 1, 1, 0, 0},
        new int[] {2, 0, 0, 1, 1, 1, 0, 0, 2}
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
        int[] pattern = patterns[Random.Range(0, patterns.Length)];
        for(int i = 0; i < spawners.Count; i++) {
            if(pattern[i] == 1) {
                Vector3 instantiatePosition = new Vector3(spawners[i].position.x, Y, .0f);
                Instantiate(tilePrefab, instantiatePosition, Quaternion.identity);
            } else if(pattern[i] == 2) {
                Vector3 instantiatePosition = new Vector3(spawners[i].position.x, Y, .0f);
                Instantiate(obstaclePrefab, instantiatePosition, Quaternion.identity);
            }
        }
        nextY = Y - distance;
    }
}
