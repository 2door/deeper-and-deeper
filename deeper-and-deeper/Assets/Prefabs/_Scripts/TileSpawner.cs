using UnityEngine;

public class TileSpawner : MonoBehaviour {
    public Transform tilePrefab;
    public float distance;

    private Vector3 nextTilePosition;

    void Start() {
        // Spawn initial tile
        SpawnTile(transform.position);
    }

    void Update() {
        // Spawn new tile after camera moves;
        if(transform.position.y <= nextTilePosition.y) {
            SpawnTile(nextTilePosition);
        }
    }

    private void SpawnTile(Vector3 spawnPosition) { 
        Vector3 instantiatePosition = new Vector3(
            spawnPosition.x,
            spawnPosition.y,
            .0f
        );
        Instantiate(tilePrefab, instantiatePosition,  Quaternion.identity);
        nextTilePosition = new Vector3(instantiatePosition.x, instantiatePosition.y - distance, .0f);
    }
}
