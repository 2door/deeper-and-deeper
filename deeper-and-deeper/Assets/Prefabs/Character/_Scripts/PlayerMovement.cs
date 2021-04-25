using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour {
    public float horizontalSpeed;
    public float verticalSpeed;
	public Rigidbody2D rb;
	public GameEvent gameOverEvent;
	public Animator playerAnimator;

	[SerializeField] private LayerMask platformLayerMask;
	private BoxCollider2D boxCollider;
	private bool gameOver;
	private bool paused;
	private bool isJumping;  // To avoid updating the animator parameter every frame
	private GameEventListener gameOverEventListener;

	private String isJumpingAnimatorFlag = "IsJumping";

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
		bool isGrounded = IsGrounded();
		if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
			playerAnimator.SetBool(isJumpingAnimatorFlag, true);
			velocity = verticalSpeed;
		}

		if(!isGrounded) {
			isJumping = true;
		} else if(isJumping) {
			playerAnimator.SetBool(isJumpingAnimatorFlag, false);
			isJumping = false;
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
