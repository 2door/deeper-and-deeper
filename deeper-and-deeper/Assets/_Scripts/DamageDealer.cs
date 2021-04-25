using UnityEngine;

public class DamageDealer : MonoBehaviour {
    public GameEvent damageDealtEvent;

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player")) {
            damageDealtEvent.Raise();
        }
    }
}
