// Camera scrolling: https://www.youtube.com/watch?v=H6q-Y5JAiDk&list=LL&index=3&t=638s&ab_channel=KeeGamedev
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float cameraOffset;
    public Transform target;
    public GameEvent gameOverEvent;

    private float zLayer;
    private float xPos;
    private bool gameOver;
    private bool paused;
    private GameEventListener gameOverEventListener;

    void Start() {
        gameOver = false;
        paused = false;
        zLayer = transform.position.z;
        xPos = transform.position.x;

        gameOverEventListener = (GameEventListener) ScriptableObject.CreateInstance("GameEventListener");
        gameOverEventListener.SetupListener(gameOverEvent, GameOver);
    }

    void FixedUpdate() {
        if(!gameOver && !paused) {
            float expectedY = target.position.y - cameraOffset;
            if(expectedY < transform.position.y) {
                Vector3 targetPos = new Vector3(xPos, expectedY, zLayer);
                transform.position = Vector3.Lerp(transform.position, targetPos, 0.2f);
            }
        }
    }

    private void GameOver() {
        gameOver = true;
    }
}
