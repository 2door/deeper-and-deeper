using UnityEngine;

public class Collectible : MonoBehaviour {
    public int pointValue;
    public GameEvent pointsCollectedEvent;

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.CompareTag("Player")) {
            pointsCollectedEvent.Raise();
            Destroy(gameObject);
        }
    }
}
