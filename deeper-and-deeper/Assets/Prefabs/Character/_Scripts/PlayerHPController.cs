using UnityEngine;

public class PlayerHPController : MonoBehaviour {
    
    public int maxHealth;
    public GameEvent damageDealtEvent;
    
    private GameEventListener damageDealtListener;
    private int hp;

    void Start() {
        hp = maxHealth;

        GameEventListener computerAttackListener = (GameEventListener) ScriptableObject.CreateInstance("GameEventListener");
        computerAttackListener.SetupListener(damageDealtEvent, TakeDamage);
    }

    private void TakeDamage() {
        hp -= 1;
        if (hp <= 0) {
            // TODO Game Over
            //gameOverEvent.Raise();
        }
    }
}
