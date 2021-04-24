using UnityEngine;
using UnityEngine.UI;

public class PlayerHPController : MonoBehaviour {
    
    public int maxHealth;
    public GameEvent damageDealtEvent;
    public GameEvent gameOverEvent;
    public Image[] containers;
    public Sprite fullContainer;
    public Sprite emptyContainer;
    
    private GameEventListener damageDealtListener;
    private int hp;

    void Start() {
        hp = maxHealth;

        damageDealtListener = (GameEventListener) ScriptableObject.CreateInstance("GameEventListener");
        damageDealtListener.SetupListener(damageDealtEvent, TakeDamage);
    }

    private void TakeDamage() {
        Debug.Log("DAMAGE");
        hp -= 1;
        UpdateHPHUD();
        if (hp <= 0) {
            gameOverEvent.Raise();
        }
    }

    private void UpdateHPHUD() {
        for(int i = 0; i < maxHealth && i < containers.Length; i ++) {
            if(i <= hp - 1) {
                containers[i].sprite = fullContainer;
            } else {
                containers[i].sprite = emptyContainer;
            }
        }
    }
}
