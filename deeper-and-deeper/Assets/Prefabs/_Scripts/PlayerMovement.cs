using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float horizontalSpeed;
    public float verticalSpeed;
	public Rigidbody2D rb;

	[SerializeField] private LayerMask platformLayerMask;
	private BoxCollider2D boxCollider;

	void Start() {
		boxCollider = transform.GetComponent<BoxCollider2D>();
	}

    void FixedUpdate() {
		Vector2 verticalVelocity = VerticalVelocity();
		Vector2 horizontalVelocity = new Vector2(Input.GetAxis("Horizontal") * horizontalSpeed, 0f);
		rb.velocity = horizontalVelocity + verticalVelocity;
    }

	private Vector2 VerticalVelocity() {
		// Clamp falling speed
		float velocity = Mathf.Clamp(rb.velocity.y, -verticalSpeed, verticalSpeed);
		if(Input.GetKeyDown(KeyCode.Space)) {
			if(IsGrounded()) {
				velocity = verticalSpeed;
			}
		}
		return new Vector2(0f, velocity);
	}

	private bool IsGrounded() {
		RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, platformLayerMask);
		Debug.Log(hit.collider);
		return hit.collider != null;
	}
}
