using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float horizontalSpeed;
    public float verticalSpeed;
	public Rigidbody2D rb;

    // Update is called once per frame
    void FixedUpdate() {
		Vector2 horizontalVelocity = new Vector2(Input.GetAxis("Horizontal") * horizontalSpeed, 0);
		Vector2 verticalVelocity = VerticalVelocity();
		rb.velocity = horizontalVelocity + verticalVelocity;
    }

	private Vector2 VerticalVelocity() {
		// Clamp falling speed
		float velocity = Mathf.Clamp(rb.velocity.y, -verticalSpeed, verticalSpeed);
		// Get jump
		return new Vector2(0, velocity);
	}
}
