using UnityEngine;

public class GameOveMenuController : MonoBehaviour {

    public GameObject gameOverMenu;
    public GameEvent gameOverEvent;
    private GameEventListener gameOverEventListener;
    void Start() {
        gameOverEventListener = (GameEventListener) ScriptableObject.CreateInstance("GameEventListener");
        gameOverEventListener.SetupListener(gameOverEvent, Show);
    }

    private void Show() {
        Debug.Log("DOING IT");
        gameOverMenu.SetActive(true);
    }
}
