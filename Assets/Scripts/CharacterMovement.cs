using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	public float speed = 5f;
	public float rotationSpeed = 720f;

	private Rigidbody rb;

	// Start is called before the first frame update
	void Start()
    {
		rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		MoveAndRotate();
    }

    void MoveAndRotate()
    {
		// Get input from WASD keys
		float moveX = Input.GetAxis("Horizontal");
		float moveZ = Input.GetAxis("Vertical");

		// Calculate the movement direction
		Vector3 moveDirection = new Vector3(moveX, 0, moveZ);

		// Check if we have some input
		if (moveDirection.magnitude > 0.1f)
		{
			// Normalize the movement vector and make it proportional to the speed per second
			moveDirection.Normalize();

			// Move the player
			rb.MovePosition(rb.position + moveDirection * speed * Time.deltaTime);

			// Calculate the target rotation based on the move direction
			Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

			// Rotate the player smoothly towards the target direction
			rb.rotation = Quaternion.RotateTowards(rb.rotation, toRotation, rotationSpeed * Time.deltaTime);
		}
	}
}
