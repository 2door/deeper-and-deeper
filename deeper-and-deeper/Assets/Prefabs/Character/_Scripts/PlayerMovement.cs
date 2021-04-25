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
	private bool isRunning;
	private GameEventListener gameOverEventListener;
	private String isJumpingAnimatorFlag = "IsJumping";
	private AudioSource jumpAudio;

	void Start() {
		boxCollider = transform.GetComponent<BoxCollider2D>();
		jumpAudio = transform.GetComponent<AudioSource>();
		gameOverEventListener = (GameEventListener) ScriptableObject.CreateInstance("GameEventListener");
        gameOverEventListener.SetupListener(gameOverEvent, GameOver);
	}

	// Using update in order to overcome input loss
    void Update() {
		if(!gameOver && !paused) {
			Vector2 verticalVelocity = VerticalVelocity();
			Vector2 horizontalVelocity = HorizontalVelocity();
			rb.velocity = horizontalVelocity + verticalVelocity;
		}
    }

	private Vector2 VerticalVelocity() {
		// Clamp falling speed
		float velocity = Mathf.Clamp(rb.velocity.y, -verticalSpeed, verticalSpeed);
		bool isGrounded = IsGrounded();
		if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
			playerAnimator.SetBool(isJumpingAnimatorFlag, true);
			jumpAudio.Play();
			velocity = verticalSpeed;
		}

		// Animate jumping
		if(!isGrounded && !isJumping) {
			isJumping = true;
		} else if(isJumping) {
			playerAnimator.SetBool(isJumpingAnimatorFlag, false);
			isJumping = false;
		}

		return new Vector2(0f, velocity);
	}

	private Vector2 HorizontalVelocity() {
		float velocity = Input.GetAxis("Horizontal") * horizontalSpeed;
		// Animate running
		if(velocity != 0f) {
			isRunning = true;
			playerAnimator.SetBool("IsRunning", true);
		} else if(isRunning) {
			isRunning = false;
			playerAnimator.SetBool("IsRunning", false);
		}

		// Flip character
		Vector2 localScale = transform.localScale;
		if(velocity > 0) {
			localScale.x = 1f;
			transform.localScale = localScale;
		} else if(velocity < 0) {
			localScale.x = -1f;
			transform.localScale = localScale;
		}

		return new Vector2(Input.GetAxis("Horizontal") * horizontalSpeed, 0f);
	}

	private bool IsGrounded() {
		RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, platformLayerMask);
		return hit.collider != null;
	}

	private void GameOver() {
		playerAnimator.SetBool("IsGameOver", true);
		gameOver = true;
	}
}
