using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float horizontalSpeed;
    public float verticalSpeed;
    public float maxVelocityChange;
	public float maxSpeedX;
	public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void FixedUpdate() {
		Vector2 velocityChange = new Vector2 (0, 0);
        velocityChange = MovementForce(Input.GetAxis("Horizontal"), 0);
        rb.AddForce(velocityChange, ForceMode2D.Force);
		
        Vector2 currentVelocity = rb.velocity;
		currentVelocity.x = Mathf.Clamp(currentVelocity.x, -maxSpeedX, maxSpeedX);
		rb.velocity = currentVelocity;
    }

	Vector2 MovementForce(float forceX, float forceY) {
		Vector2 velocityChange = new Vector2 ();
		// Input taking when tilting
		Vector2 targetVelocityH = new Vector2(forceX, 0);
		Vector2 targetVelocityV = new Vector2(0, forceY);
		targetVelocityH = transform.TransformDirection(targetVelocityH);
		targetVelocityH *= horizontalSpeed;
		targetVelocityV = transform.TransformDirection(targetVelocityV);
		targetVelocityV *= verticalSpeed;

		// Apply a force that attempts to reach our target velocity
		Vector2 velocity = rb.velocity;
		velocityChange = (targetVelocityH - velocity);

		velocityChange = (targetVelocityH + targetVelocityV - velocity);
		// Make sure change not too sudden
		velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
		velocityChange.y = Mathf.Clamp(velocityChange.y, -maxVelocityChange, maxVelocityChange);
		return velocityChange;
	}
}
