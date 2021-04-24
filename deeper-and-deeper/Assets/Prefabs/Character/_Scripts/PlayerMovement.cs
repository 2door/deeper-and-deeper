using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float horizontalSpeed;
    public float verticalSpeed;
	public Rigidbody2D rb;
	public GameEvent gameOverEvent;

	[SerializeField] private LayerMask platformLayerMask;
	private BoxCollider2D boxCollider;
	private bool gameOver;
	private bool paused;
	private GameEventListener gameOverEventListener;

	void Start() {
		boxCollider = transform.GetComponent<BoxCollider2D>();
		gameOverEventListener = (GameEventListener) ScriptableObject.CreateInstance("GameEventListener");
        gameOverEventListener.SetupListener(gameOverEvent, GameOver);
	}

	// Using update in order to overcome input loss
    void Update() {
		if(!gameOver && !paused) {
				Vector2 verticalVelocity = VerticalVelocity();
				Vector2 horizontalVelocity = new Vector2(Input.GetAxis("Horizontal") * horizontalSpeed, 0f);
				rb.velocity = horizontalVelocity + verticalVelocity;
		}
    }

	private Vector2 VerticalVelocity() {
		// Clamp falling speed
		float velocity = Mathf.Clamp(rb.velocity.y, -verticalSpeed, verticalSpeed);
		if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
			velocity = verticalSpeed;
		}
		return new Vector2(0f, velocity);
	}

	private bool IsGrounded() {
		RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, platformLayerMask);
		return hit.collider != null;
	}

	private void GameOver() {
		gameOver = true;
	}
}
